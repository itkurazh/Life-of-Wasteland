using UnityEngine;

public class StateBehaviourNone : StateBehaviour
{
    public StateBehaviourNone(UnitData data, UnitView view) : base(data, view) { }

    public override StateID ID() => StateID.None;

    public override void Enter()
    {
        
    }

    public override void Update()
    {
        
    }

    public override void Exit()
    {
        
    }
}