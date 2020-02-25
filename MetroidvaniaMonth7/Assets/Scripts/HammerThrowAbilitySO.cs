using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/ThrowAbility")]
public class HammerThrowAbilitySO : AbilitySO
{

    [SerializeField]
    float throwSpeed;
    [SerializeField]
    PlayerStateSO playerState;

    IThrow throwHammer;

    public override void Initialize(GameObject obj)
    {
        throwHammer = obj.GetComponent<IThrow>();
        throwHammer.ThrowSpeed = throwSpeed;
        throwHammer.InitializeThrow();
    }

    public override void UseAbilityTick()
    {
            throwHammer.ThrowAttackTick();
    }
}
