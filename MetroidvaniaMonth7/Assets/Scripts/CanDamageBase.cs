using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CanDamageBase : MonoBehaviour, ICanDamage
{
    protected bool canDamage = true;
    public bool CanDamage { get => canDamage; set => canDamage = value; }

    protected abstract bool CanHit();

}
