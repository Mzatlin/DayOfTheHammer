using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunBase : MonoBehaviour, IStunnable
{
    public event Action OnStun = delegate { };
    [SerializeField]
    protected bool isStunned = false;

    public bool IsStunned { get => isStunned; set => isStunned = value; }

    protected virtual void ProcessStun()
    {
        HandleStun();
    }

    public void HandleStun()
    {
        OnStun();
    }

}
