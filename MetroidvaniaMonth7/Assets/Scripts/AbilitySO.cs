using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilitySO : ScriptableObject
{
    public string assetname = "New Ability";
    public abstract void Initialize(GameObject obj);
    public abstract void UseAbilityTick();
}
