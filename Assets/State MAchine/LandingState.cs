using UnityEngine;

public class LandingState : BaseState
{
    public override void OnEnter()
    {
        plane.SetAnimState(4);
        Debug.Log("Entering Landing State");
    }

    public override void Update()
    {
        plane.GlideTowardsTarget();
    }

    public override void OnExit()
    {
        Debug.Log("Exiting Landing State");
    }
}
