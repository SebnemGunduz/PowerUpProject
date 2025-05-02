using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlaneFSM : MonoBehaviour
{
    public GameObject Plane;
    [HideInInspector]
    public bool isReadyToFly = false;
    public Vector3 landingTarget;

    [Header("Elle Hedef Noktasý (X/Y)")]
    public float targetX;
    public float targetY;

    [Header("Hareket Ayarlarý")]
    public float takeoffHeight = 2f;
    public float takeoffWeight = 2f;
    public float levitatingSpeed = .2f;
    public float speed = 5f;
    public float rotateSpeed = 2f;
    private Animator anim;

    private IState currentState;
    private Vector3 takeoffTarget;

    public void SetAnimState(int stateValue)
    {
        if (anim != null)
        {
            anim.SetInteger("State", stateValue);
        }
    }

    void Start()
    {
        Plane = this.gameObject;
        anim = GetComponent<Animator>();
        currentState = new IdleState();
        currentState.SetContext(this);
        currentState.OnEnter();

        if (landingTarget == Vector3.zero)
        {
            landingTarget = new Vector3(targetX, targetY, transform.position.z);
        }
    }

    void Update()
    {
        currentState?.Update();
    }

    public void ChangeState(BaseState newState)
    {
        currentState?.OnExit();
        currentState = newState;
        currentState.SetContext(this);
        currentState.OnEnter();
    }

    public void OnSelectFinished()
    {
        takeoffTarget = transform.position + Vector3.up * takeoffHeight + Vector3.right * takeoffWeight;
        Invoke("TransitionToTakingOff", 1f);
    }

    void TransitionToTakingOff()
    {
        ChangeState(new TakingOffState());
    }

    public void OnTakingOffFinished()
    {
        transform.position = Vector3.MoveTowards(transform.position, takeoffTarget, levitatingSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, takeoffTarget) < 0.01f)
            ChangeState(new AlignmentState());
    }

    public void RotateTowardsTarget()
    {
        Vector3 direction = landingTarget - transform.position.normalized;
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, -direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

        if (Quaternion.Angle(transform.rotation, targetRotation) < 1f)
        {
            OnAlignmentFinished();
        }
    }

    public void OnAlignmentFinished()
    {
        ChangeState(new LandingState());
    }

    public void GlideTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, landingTarget, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, landingTarget) < 0.1f)
        {
            ChangeState(new CrashState());
        }
    }

    public void DestroyObject()
    {
        Invoke("OnCrashFinished", 1f);
    }

    public void OnCrashFinished()
    {
        Destroy(Plane);
    }
}
