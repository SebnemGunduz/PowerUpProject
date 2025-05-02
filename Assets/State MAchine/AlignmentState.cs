using UnityEngine;

public class AlignmentState : IState
{
    public void EnterState(PlaneFSM plane)
    {
        plane.SetAnimState(3);
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
