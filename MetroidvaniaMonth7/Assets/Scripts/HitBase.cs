using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBase : MonoBehaviour, IHittable
{
    public event Action OnHit = delegate { };
    public event Action<Transform> OnHitTransform = delegate { };

    public void ProcessHit()
    {
        HandleHit(1f);
        //Sound when hit
      //  FMODUnity.RuntimeManager.PlayOneShot("event:/Objects/Hit");
    }

    public void ProcessHit(float damage)
    {
        HandleHit(damage);
    }

    public void ProcessHit(Transform trans)
    {
        HandleHitTransform(trans);
    }

    protected virtual void HandleHitTransform(Transform trans)
    {
        OnHitTransform(trans);
    }

    protected virtual void HandleHit(float damage)
    {
        OnHit();
    }


}
