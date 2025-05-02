public abstract class BaseState : IState
{
    protected PlaneFSM plane;

    // SetContext metodu burada implemente ediliyor
    public void SetContext(PlaneFSM plane)
    {
        this.plane = plane;
    }

    public virtual void OnEnter() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void OnExit() { }
}
