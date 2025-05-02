using UnityEngine;

public class CrashState : BaseState
{
    public override void OnEnter()
    {
        plane.SetAnimState(5);
        Debug.Log("Entering Crash State");
    }

    public override void Update()
    {
        plane.DestroyObject();
    }

    public override void OnExit()
    {
        Debug.Log("Exiting Crash State");
    }
}
