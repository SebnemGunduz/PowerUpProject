using UnityEngine;

public class TakingOffState : BaseState
{
    public override void OnEnter()
    {
        plane.SetAnimState(2);
        Debug.Log("Entering Taking Off State");
    }

    public override void Update()
    {
        plane.OnTakingOffFinished();
    }

    public override void OnExit()
    {
        Debug.Log("Exiting Taking Off State");
    }
}
