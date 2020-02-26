using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootProjectile 
{
    float FireRate { get; }
    void FireWeapon();
    Vector2 CalculateDirection();
    bool CanFire();
}
