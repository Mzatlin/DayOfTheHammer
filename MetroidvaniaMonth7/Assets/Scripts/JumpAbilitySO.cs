using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/JumpAbility")]
public class JumpAbilitySO : AbilitySO
{
    [SerializeField]
    float jumpPower;

    private Jump _jump;

    public override void Initialize(GameObject obj)
    {
        _jump = obj.GetComponent<Jump>();
        _jump.jumpPower = jumpPower;
    }

    public override void UseAbilityTick()
    {

    }
}
