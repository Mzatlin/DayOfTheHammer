using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IHittable
{
    event Action OnHit;
    void ProcessHit();
}
