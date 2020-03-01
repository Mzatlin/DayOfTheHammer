using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LiftBase : MonoBehaviour, ILift
{
    public event Action<float> OnLift = delegate { };

    public void ProcessLift(float force)
    {
        HandleLift(force);
    }
    protected void HandleLift(float force)
    {
        OnLift(force);
    }
}
