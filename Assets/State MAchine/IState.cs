public interface IState
{
    void SetContext(PlaneFSM plane);  // Context set metodu eklenmeli
    void OnEnter();
    void Update();
    void FixedUpdate();
    void OnExit();
}
