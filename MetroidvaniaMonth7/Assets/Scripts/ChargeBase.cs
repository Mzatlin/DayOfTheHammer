using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeBase : MonoBehaviour, IChargeable
{

    [SerializeField]
    protected float timeToCharge = 1.5f;
    protected float targetDistance = 0f;
    protected float holdDownTime = 0f;
    [SerializeField]
    protected LayerMask finalLayerMask;

    public float HoldDownTime => holdDownTime;

    public float TimeToCharge { get => timeToCharge; set => timeToCharge = value; }

    protected virtual bool CanRelease()
    {
        if (holdDownTime > timeToCharge)
        {
            holdDownTime = 0;
            return true;
        }
        else
        {
            return false;
        }
    }

    protected virtual void ProcessHammerCharge(Collider2D obj)
    {
        targetDistance = CalculateDistance(obj);
    }

    protected float CalculateDistance(Collider2D obj)
    {
        return Vector3.Distance(obj.transform.position, transform.position);
    }
}
