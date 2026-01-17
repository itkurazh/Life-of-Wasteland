using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Unit _unit;

    private void Start()
    {
        _unit.TeleportTo(Vector3.zero);
    }

    private void Update()
    {
        _unit.Data.IsRunning = Input.GetKey(KeyCode.LeftShift);
        
        if(Input.GetKey(KeyCode.A))
            Move(GlobalDirection.Backward);
        else if(Input.GetKey(KeyCode.D))
            Move(GlobalDirection.Forward);
        else
        {
            StopMove();
        }
    }

    private void Move(GlobalDirection direction)
    {
        var velocity = _unit.Data.Velocity;

        if (direction == GlobalDirection.Backward)
            velocity = Vector3.back;
        else if (direction == GlobalDirection.Forward)
            velocity = Vector3.forward;

        if (_unit.Data.IsRunning)
            velocity *= _unit.Config.SpeedRun;
        else
            velocity *= _unit.Config.SpeedWalk;

        _unit.Data.Velocity = Vector3.Lerp(_unit.Data.Velocity, velocity, UnitConstants.LERP_VALUE * Time.deltaTime);
    }

    private void StopMove()
    {
        _unit.Data.Velocity = Vector3.zero;
    }
}