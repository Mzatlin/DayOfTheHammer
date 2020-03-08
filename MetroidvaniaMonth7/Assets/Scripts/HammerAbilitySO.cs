using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/HammerAbility")]
public class HammerAbilitySO : AbilitySO
{
    [SerializeField]
    float attackRange;
    [SerializeField]
    float swingSpeed;

    private IHammer hammerAttack;

    public override void Initialize(GameObject obj)
    {
        hammerAttack = obj.GetComponent<IHammer>();
        hammerAttack.Initialize();
        hammerAttack.AttackRange = attackRange;
        hammerAttack.SwingSpeed = swingSpeed;
    }

    public override void UseAbilityTick()
    {
        hammerAttack.HammerAttackTick();
    }
}
