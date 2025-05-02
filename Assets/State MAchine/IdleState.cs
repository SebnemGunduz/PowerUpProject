using UnityEngine;

public class IdleState : BaseState
{
    public override void OnEnter()
    {
        Debug.Log("Entering Idle State");
    }

    public override void Update()
    {
        if (plane.isReadyToFly)
        {
            plane.ChangeState(new SelectState());
        }
    }

    public override void OnExit()
    {
        Debug.Log("Exiting Idle State");
    }
}
