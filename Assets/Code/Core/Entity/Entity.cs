using System;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected virtual void Awake()
    {
        Subscribe();
    }

    protected virtual void Subscribe()
    {
        
    }
    
    protected virtual void Unsubscribe()
    {
        
    }

    protected void OnDestroy()
    {
        Unsubscribe();
    }
}