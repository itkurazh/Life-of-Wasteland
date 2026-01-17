using UnityEngine;

public class StateBehaviourLocomotion : StateBehaviour
{
    public StateBehaviourLocomotion(UnitData data, UnitView view) : base(data, view) { }

    public override StateID ID() => StateID.Locomotion;

    public override void Enter()
    {
        base.Enter();
        
        Data.IsMoving = true;
        Data.Direction = Data.Velocity.normalized;
    }

    public override void Update()
    {
        base.Update();

        if (Data.Velocity != Vector3.zero)
        {
            Data.Rotation = Data.Velocity.normalized;
            Data.Position += Data.Velocity * Time.deltaTime;
        }
        
        Data.Direction = Data.Velocity.normalized;
    }

    public override void Exit()
    {
        base.Exit();
        
        Data.IsMoving = false;
    }
}