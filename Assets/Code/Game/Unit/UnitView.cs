using System;
using NaughtyAttributes;
using UnityEngine;

public class UnitView  : MonoBehaviour
{
    public const string ANIMATOR_VELOCITY = "Velocity";
    
    [BoxGroup("References"), SerializeField] private Animator _animator;
    
    private UnitData _data;

    public void SetData(UnitData data)
    {
        _data = data;
    }
    
    private void Update()
    {
        Locomotion();
    }

    private void Locomotion()
    {
        float velocity = _animator.GetFloat(ANIMATOR_VELOCITY);
        
        if (_data.State == StateID.Locomotion)
        {
            if(_data.IsRunning)
            {
                LerpTo(ANIMATOR_VELOCITY, velocity, 2);
            }
            else
            {
                LerpTo(ANIMATOR_VELOCITY, velocity, 1);
            }
        }
        else
        {
            LerpTo(ANIMATOR_VELOCITY, velocity, 0);
        }
    }

    private void LerpTo(string name, float from, float to)
    {
        _animator.SetFloat(name, Mathf.Lerp(from, to, UnitConstants.LERTP_VALUE * Time.deltaTime));
    }
}