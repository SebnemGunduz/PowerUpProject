using UnityEngine;

public class SelectState : BaseState
{
    public override void OnEnter()
    {
        plane.SetAnimState(1);
        Debug.Log("Entering Select State");
        plane.OnSelectFinished();
    }

    public override void Update() { }

    public override void OnExit()
    {
        Debug.Log("Exiting Select State");
    }
}
