using UnityEngine;

public class StateBehaviourLocomotion : StateBehaviour
{
    public StateBehaviourLocomotion(UnitData data, UnitView view) : base(data, view) { }

    public override StateID ID() => StateID.Locomotion;

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if (Data.Velocity != Vector3.zero)
        {
            View.transform.rotation = Quaternion.LookRotation(Data.Velocity.normalized);
            View.transform.Translate(Data.Velocity * Time.deltaTime, Space.World);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}