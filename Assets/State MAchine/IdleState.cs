using Unity.VisualScripting;
using UnityEngine;

public class IdleState : IState
{
    public void EnterState(PlaneFSM plane)
    {
        Debug.Log("Entering Idle State");
    }

    public void ExitState(PlaneFSM plane)
    {
        Debug.Log("Exiting Idle State");
    }

    public void UpdateState(PlaneFSM plane)
    {
        if (plane.isReadyToFly)
        {
            plane.ChangeState(new SelectState());
        }
    }
}
