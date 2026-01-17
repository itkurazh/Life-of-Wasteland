using System.Collections.Generic;
using UnityEngine;

public class Unit : Entity
{
    public UnitData Data => _data;
    public UnitConfig Config => _config;
    
    [SerializeField] private UnitView _view;
    [SerializeField] private UnitConfig _config;
    private UnitData _data;

    private Dictionary<StateID, StateBehaviour> _state;

    protected override void Awake()
    {
        base.Awake();
        
        _data = new UnitData();
        _view.SetData(_data);
        
        _state = new Dictionary<StateID, StateBehaviour>()
        {
            { StateID.None , new StateBehaviourNone(_data, _view) },
            { StateID.Idle , new StateBehaviourIdle(_data, _view) },
            { StateID.Locomotion , new StateBehaviourLocomotion(_data, _view) }
        };
    }
    
    protected virtual void Start()
    {
        SwitchState(StateID.Idle);
    }

    protected virtual void Update()
    {
        StateMachine();
        
        if(_data.Velocity != Vector3.zero)
        {
            SwitchState(StateID.Locomotion);
        }
        else
        {
            SwitchState(StateID.Idle);
        }
    }
    
    public void TeleportTo(Vector3 position)
    {
     
    }

    public void SwitchState(StateID newState)
    {
        if(_data.State == newState)
            return;
        
        Debug.Log($"{transform.name} switched state from {_data.State} to {newState}");
        
        _state[_data.State].Exit();
        _data.State = newState;
        _state[_data.State].Enter();
    }

    private void StateMachine()
    {
        if(_data.State == StateID.None)
            return;
        
        _state[_data.State].Update();
    }
}
