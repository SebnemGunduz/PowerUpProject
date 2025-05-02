using UnityEngine;

public class AlignmentState : BaseState
{
    public override void OnEnter()
    {
        plane.SetAnimState(3);
        Debug.Log("Entering Alignment State");
    }

    public override void Update()
    {
        plane.RotateTowardsTarget();
    }

    public override void OnExit()
    {
        Debug.Log("Exiting Alignment State");
    }
}
