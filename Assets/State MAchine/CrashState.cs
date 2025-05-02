using UnityEngine;

public class CrashState : IState
{
    public void EnterState(PlaneFSM plane)
    {
        plane.SetAnimState(5);
        Debug.Log("Entering Crash State");
    }

    public void ExitState(PlaneFSM plane)
    {
        Debug.Log("Entering Crash State");
    }

    public void UpdateState(PlaneFSM plane)
    {
        plane.DestroyObject();
    }
}
