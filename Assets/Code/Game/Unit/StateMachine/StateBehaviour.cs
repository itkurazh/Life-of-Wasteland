using UnityEngine;

public abstract class StateBehaviour
{
    public abstract StateID ID();

    protected UnitData Data;
    protected UnitView View;

    public StateBehaviour(UnitData data, UnitView view)
    {
        Data = data;
        View = view;
    }

    public virtual void Enter()
    {
        //Debug.Log($"Entering {ID()}");
    }

    public virtual void Update()
    {
       // Debug.Log($"Updating {ID()}");
    }

    public virtual void Exit()
    {
        //Debug.Log($"Exit {ID()}");
    }
}