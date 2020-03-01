using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface ILift
{
    event Action<float> OnLift;
    void ProcessLift(float force);
}
