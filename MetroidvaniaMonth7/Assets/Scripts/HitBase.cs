using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBase : MonoBehaviour, IHittable
{
    public event Action OnHit = delegate { };

    public void ProcessHit()
    {
        HandleHit();

        //Sound when hit
        FMODUnity.RuntimeManager.PlayOneShot("event:/Objects/Hit");



    }

    protected virtual void HandleHit()
    {
        OnHit();
    }

}
