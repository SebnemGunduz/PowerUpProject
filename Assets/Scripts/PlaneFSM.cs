using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlaneFSM : MonoBehaviour
{
    public GameObject Plane;

    [Header("Elle Hedef Noktasý (X/Y)")]
    public float targetX;
    public float targetY;

    [Header("Hareket Ayarlarý")]
    public float takeoffHeight = 2f;
    public float takeoffWeight = 2f;
    public float levitatingSpeed = .2f;
    public float speed = 5f;
    public float rotateSpeed = 2f;

    enum State { IdleAnim = 0, SelectAnim = 1, TakingOffAnim = 2, AlignmentAnim = 3, LandingAnim = 4, CrashAnim = 5 }
    State state = State.IdleAnim;

    Animator anim;
    static readonly int StateHash = Animator.StringToHash("State");

    Vector3 takeoffTarget;
    Vector3 landingTarget;
    bool isLevitating = false;
    bool isRotating = false;
    bool isLanding = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        // Elle girilen hedef pozisyonu hazýrlýyoruz.
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
                Invoke("OnSelectFinished", 1f); // Animasyon süremizin 1 saniye süremesinden kaynaklý 1f'lik deðer verilmiþtir.
                break;

            case State.TakingOffAnim:
                transform.position = Vector3.MoveTowards(transform.position, takeoffTarget, levitatingSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, takeoffTarget) < 0.01f)
                    if (isLevitating)
                        SetState(State.AlignmentAnim);
                break;

            case State.AlignmentAnim:
                RotateTowardsTarget();          
                break;

            case State.LandingAnim:
                if (isLanding)
                    GlideTowardsTarget();
                break;

            case State.CrashAnim:
                Invoke("OnCrashFinished", 1f); // Animasyon süremizin 1 saniye süremesinden kaynaklý 1f'lik deðer verilmiþtir.
                break;
        }
    }

    void SetState(State newState)
    {
        state = newState;
        anim.SetInteger(StateHash, (int)newState);

        if (newState == State.TakingOffAnim)
            isLevitating = true;

        if (newState == State.AlignmentAnim)
            isRotating = true;

        if (newState == State.LandingAnim)
            isLanding = true;
    }

    public void OnSelectFinished()
    {
        takeoffTarget = transform.position + Vector3.up * takeoffHeight + Vector3.right * takeoffWeight; // Uçaðýmýz yükselmesi ve hedefin üstünde konumlanmasý için hedefin bize göre yüksekliði ayarlanmýþtýr.
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


    void RotateTowardsTarget()
    {
        Vector3 direction = (landingTarget - (transform.position + Vector3.left * 5 + Vector3.down * 11)).normalized; // Verilmiþ olan animasyonlara göre uçaðýn hedef noktasýna göre bakýþ açýsý ayarlanmýþtýr.
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

        if (Quaternion.Angle(transform.rotation, targetRotation) < 1f)
        {
            OnAlignmentFinished(); // Rotate iþlemi tamamlandý.
        }
    }

    void GlideTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, landingTarget, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, landingTarget) < 0.1f)
        {
            isLanding = false;
            SetState(State.CrashAnim); // Glide iþlemi tamamlandý.
        }
    }
}
