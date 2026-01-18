using System;
using NaughtyAttributes;
using UnityEngine;

public partial class UnitView  : MonoBehaviour
{
    [BoxGroup("References"), SerializeField] private Animator _animator;

    private Vector3 _directionMove;
    private Vector3 _position;
    private Quaternion _rotation;
    
    private UnitData _data;

    public float Timer;
    
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
        Movement();

        Velocity();
        
        Locomotion();

        GizmoUpdate();

        Timer = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    private void Movement()
    {
        transform.position = Vector3.Lerp(transform.position, _position, UnitConstants.LERP_VALUE * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, _rotation, UnitConstants.LERP_VALUE / 2f * Time.deltaTime);
    }

    private void Velocity()
    {
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

    private void Locomotion()
    {
        float directionFrom = _animator.GetFloat(UnitConstants.ANIMATOR_DIRECTION);
        float directionTo = Vector3.Dot(_data.Direction, transform.right) * 180;
        float startDirection = Vector3.Dot(_data.Direction, transform.forward);
        
        LerpTo(UnitConstants.ANIMATOR_DIRECTION, directionFrom, directionTo);

        if (_data.IsMoving && _animator.GetFloat(UnitConstants.ANIMATOR_START_DIRECTION) == 0)
        {
            
            if(startDirection > 0)
                _animator.SetFloat(UnitConstants.ANIMATOR_START_DIRECTION, directionTo);
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
    }

    private void LerpTo(string name, float from, float to)
    {
        _animator.SetFloat(name, Mathf.Lerp(from, to, UnitConstants.LERP_VALUE * Time.deltaTime));
    }
}