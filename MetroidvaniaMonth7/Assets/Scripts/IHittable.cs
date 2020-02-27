using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IHittable
{
    event Action OnHit;
    event Action<Transform> OnHitTransform;
    void ProcessHit(float damage);
    void ProcessHit();
    void ProcessHit(Transform trans);
}
