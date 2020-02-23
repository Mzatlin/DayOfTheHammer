using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeBase : MonoBehaviour, IChargeable
{
    public event Action OnChargeBegin;
    public event Action OnChargeEnd;

    [SerializeField]
    protected float holdDownTime = 0f;
    [SerializeField]
    protected float timeToCharge = 1.5f;

    public float HoldDownTime => holdDownTime;

    public float TimeToCharge { get => timeToCharge; set => timeToCharge = value; }
    
    protected virtual bool CanRelease()
    {
        if(holdDownTime > timeToCharge)
        {
            holdDownTime = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
}
