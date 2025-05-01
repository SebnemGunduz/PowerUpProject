using UnityEngine;

public interface IState
{
    void EnterState(PlaneFSM plane);
    void UpdateState(PlaneFSM plane);
    void ExitState(PlaneFSM plane);
}
