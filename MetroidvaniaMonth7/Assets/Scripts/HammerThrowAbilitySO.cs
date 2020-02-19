using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/ThrowAbility")]
public class NewBehaviourScript : AbilitySO
{

    [SerializeField]
    float throwSpeed;

    IThrow throwHammer;

    public override void Initialize(GameObject obj)
    {
        throwHammer = obj.GetComponent<ThrowHammer>();
        throwHammer.ThrowSpeed = throwSpeed;
        throwHammer.InitializeThrow();
    }

    public override void UseAbilityTick()
    {
        throwHammer.ThrowAttackTick();
    }
}
