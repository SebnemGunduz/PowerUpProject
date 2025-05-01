using UnityEngine;

public class CrashState : IState
{
    public void EnterState(PlaneFSM plane)
    {
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
