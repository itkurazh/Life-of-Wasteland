using System;
using UnityEngine;

public sealed class UnitData
{
    public StateID State;

    public Action<Vector3> OnChangePosition;
    private Vector3 position;
    public Vector3 Position
    {
        get => position;
        set
        {
            position = value;
            OnChangePosition?.Invoke(position);
        }
    }
    
    public Action<Vector3> OnChangeRotation;
    private Vector3 rotation;
    public Vector3 Rotation
    {
        get => rotation;
        set
        {
            rotation = value;
            OnChangeRotation?.Invoke(rotation);
        }
    }
    
    public Vector3 Direction;
    public Vector3 Velocity;

    public bool IsMoving;
    public bool IsRunning;
}