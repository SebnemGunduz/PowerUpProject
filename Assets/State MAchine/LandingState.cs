using UnityEngine;

public class LandingState : IState
{
    public void EnterState(PlaneFSM plane)
    {
        Debug.Log("Entering Landing State");
    }

    public void ExitState(PlaneFSM plane)
    {
        Debug.Log("Entering Landing State");
    }

    public void UpdateState(PlaneFSM plane)
    {
        plane.GlideTowardsTarget();
    }
}
