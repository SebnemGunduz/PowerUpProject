using UnityEngine;

public class SelectState : IState
{
    public void EnterState(PlaneFSM plane)
    {
        plane.SetAnimState(1);
        Debug.Log("Entering Select State");
        plane.OnSelectFinished();
    }

    public void ExitState(PlaneFSM plane)
    {
        Debug.Log("Exiting Select State");
    }

    public void UpdateState(PlaneFSM plane)
    {

    }
}
