public class StateBehaviourIdle : StateBehaviour
{
    public StateBehaviourIdle(UnitData data, UnitView view) : base(data, view) { }

    public override StateID ID() => StateID.Idle;

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }
}