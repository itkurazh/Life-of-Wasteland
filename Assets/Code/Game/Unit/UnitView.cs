using System;
using NaughtyAttributes;
using UnityEngine;

public partial class UnitView  : MonoBehaviour
{
    [BoxGroup("References"), SerializeField] private Animator _animator;

    private Vector3 _position;
    private Quaternion _rotation;
    
    private UnitData _data;
    
    public void SetData(UnitData data)
    {
        _data = data;
        
        _data.OnChangePosition += OnChangePosition;
        _data.OnChangeRotation += OnChangeRotation;
    }

    public void ClearData()
    {
        _data.OnChangePosition -= OnChangePosition;
        _data.OnChangeRotation -= OnChangeRotation;
        
        _data = null;
    }
    
    private void OnChangePosition(Vector3 position)
    {
        _position = position;
    }
    
    private void OnChangeRotation(Vector3 rotation)
    {
        _rotation = Quaternion.LookRotation(rotation);
    }

    private void Update()
    {
        Locomotion();

        GizmoUpdate();
    }

    private void Locomotion()
    {
        float forwardDot = Vector3.Dot(_data.Direction, transform.forward);
        forwardDot = Mathf.Clamp(forwardDot, 0, 1);
        
        transform.position = Vector3.Lerp(transform.position, _position, UnitConstants.LERP_VALUE * forwardDot * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, _rotation, UnitConstants.LERP_VALUE / 2f * Time.deltaTime);
        
        float direction = Vector3.Dot(_data.Direction, transform.right) * 180;
        _animator.SetFloat(UnitConstants.ANIMATOR_DIRECTION, direction);

        if (_data.IsMoving && _animator.GetFloat(UnitConstants.ANIMATOR_START_DIRECTION) == 0)
        {
            float startDirection = Vector3.Dot(_data.Direction, transform.forward);
            
            if(startDirection > 0)
                _animator.SetFloat(UnitConstants.ANIMATOR_START_DIRECTION, direction);
            else
            {
                if(_data.Direction.z < 0)
                    startDirection = -startDirection;
                
                _animator.SetFloat(UnitConstants.ANIMATOR_START_DIRECTION, startDirection * 180);
            }
            
        }
        else if(!_data.IsMoving)
        {
            _animator.SetFloat(UnitConstants.ANIMATOR_START_DIRECTION, 0);
        }
        
        float velocity = _animator.GetFloat(UnitConstants.ANIMATOR_VELOCITY);
        
        if (_data.State == StateID.Locomotion)
        {
            if(_data.IsRunning)
            {
                LerpTo(UnitConstants.ANIMATOR_VELOCITY, velocity, 1);
            }
            else
            {
                LerpTo(UnitConstants.ANIMATOR_VELOCITY, velocity, 0.7f);
            }
        }
        else
        {
            LerpTo(UnitConstants.ANIMATOR_VELOCITY, velocity, 0);
        }
    }

    private void LerpTo(string name, float from, float to)
    {
        _animator.SetFloat(name, Mathf.Lerp(from, to, UnitConstants.LERP_VALUE * Time.deltaTime));
    }
}