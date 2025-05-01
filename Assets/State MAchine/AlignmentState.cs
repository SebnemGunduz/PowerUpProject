using UnityEngine;

public class AlignmentState : IState
{
    public void EnterState(PlaneFSM plane)
    {
        Debug.Log("Entering Alignment State");
    }

    public void ExitState(PlaneFSM plane)
    {
        Debug.Log("Entering Alignment State");
    }

    public void UpdateState(PlaneFSM plane)
    {
        plane.RotateTowardsTarget();
    }
}
