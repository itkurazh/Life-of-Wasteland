using UnityEngine;

[System.Serializable]
public class UnitData
{
    public UnitView View { get; private set; }
    
    public StateID State;
    
    public Vector3 Position;
    public Vector3 Rotation;
    
    public Vector3 Velocity;
    
    public bool IsRunning;

    public UnitData(UnitView view)
    {
        View = view;
        
        View.SetData(this);
    }
}