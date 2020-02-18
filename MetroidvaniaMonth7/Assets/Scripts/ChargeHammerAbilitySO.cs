using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/ChargeAbility")]
public class ChargeHammerAbilitySO : AbilitySO
{
    [SerializeField]
    float chargeRadius;

    private ChargeHammerAttack chargeAttack;

    public override void Initialize(GameObject obj)
    {
        chargeAttack = obj.GetComponent<ChargeHammerAttack>();
        chargeAttack.Initialize();
        chargeAttack.chargeRadius = chargeRadius;
    }

    public override void UseAbilityTick()
    {
        chargeAttack.HammerCharge();
    }
}
