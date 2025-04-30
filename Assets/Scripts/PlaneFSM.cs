using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlaneFSM : MonoBehaviour
{
    public GameObject Plane;

    [Header("Elle Hedef Noktas� (X/Y)")]
    public float targetX;
    public float targetY;

    [Header("Hareket Ayarlar�")]
    public float takeoffHeight = 2f;
    public float speed = 5f;
    public float rotateSpeed = 2f;

    enum State { IdleAnim = 0, SelectAnim = 1, TakingOffAnim = 2, AlignmentAnim = 3, LandingAnim = 4, CrashAnim = 5 }
    State state = State.IdleAnim;

    Animator anim;
    static readonly int StateHash = Animator.StringToHash("State");

    Vector3 takeoffTarget;
    Vector3 landingTarget;
    bool isRotating = false;
    bool isLanding = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        // Elle girilen hedef pozisyonu haz�rl�yoruz (Z ekseni sabit kal�yor)
        landingTarget = new Vector3(targetX, targetY, transform.position.z);
    }

    void Update()
    {
        switch (state)
        {
            case State.IdleAnim:
                if (Input.GetKeyDown(KeyCode.S))
                    SetState(State.SelectAnim);
                break;

            case State.SelectAnim:
                Invoke("OnSelectFinished", 1f); // Animasyon s�remizin 1 saniye s�remesinden kaynakl� 1f'lik de�er verilmi�tir.
                break;

            case State.TakingOffAnim:
                transform.position = Vector3.MoveTowards(transform.position, takeoffTarget, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, takeoffTarget) < 0.01f)
                    SetState(State.AlignmentAnim);
                break;

            case State.AlignmentAnim:
                if (isRotating)
                    RotateTowardsTarget();
                break;

            case State.LandingAnim:
                if (isLanding)
                    GlideTowardsTarget();
                break;

            case State.CrashAnim:
                // Crash animasyonu oynarken yok etme fonksiyonu tetiklenecek
                break;
        }
    }

    public void OnSelectFinished()
    {
        takeoffTarget = transform.position + Vector3.up * takeoffHeight; // U�a��m�z y�kselmesi i�in hedefin bize g�re y�ksekli�i ayarlanm��t�r.
        SetState(State.TakingOffAnim);
    }

    public void OnAlignmentFinished()
    {
        isRotating = false;
        SetState(State.LandingAnim);
    }

    public void OnCrashFinished()
    {
        Destroy(Plane);
    }

    void SetState(State newState)
    {
        state = newState;
        anim.SetInteger(StateHash, (int)newState);

        if (newState == State.AlignmentAnim)
            isRotating = true;

        if (newState == State.LandingAnim)
            isLanding = true;
    }

    void RotateTowardsTarget()
    {
        Vector3 direction = (landingTarget - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction); // 2D i�in
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

        if (Quaternion.Angle(transform.rotation, targetRotation) < 1f)
        {
            OnAlignmentFinished(); // d�n�� tamamland�
        }
    }

    void GlideTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, landingTarget, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, landingTarget) < 0.1f)
        {
            isLanding = false;
            SetState(State.CrashAnim); // ini� tamamland�
        }
    }
}
