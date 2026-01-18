using NaughtyAttributes;
using UnityEngine;

public partial class Entity
{
    [BoxGroup("Debug"), SerializeField] private bool _isEnabledDebug = false;
    
    protected bool IsEnabledDebug() => _isEnabledDebug;
}