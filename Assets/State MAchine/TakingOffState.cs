using UnityEngine;

public class TakingOffState : IState
{
    public void EnterState(PlaneFSM plane)
    {
        plane.SetAnimState(2);
        Debug.Log("Entering Select State");
    }

    public void ExitState(PlaneFSM plane)
    {
        Debug.Log("Exiting Taking Off State");
    }

    public void UpdateState(PlaneFSM plane)
    {
        plane.OnTakingOffFinished();
    }
}
