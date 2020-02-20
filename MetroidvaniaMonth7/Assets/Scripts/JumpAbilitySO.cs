using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/JumpAbility")]
public class JumpAbilitySO : AbilitySO
{
    [SerializeField]
    float jumpPower;

    private IJump _jump;

    public override void Initialize(GameObject obj)
    {
        _jump = obj.GetComponent<IJump>();
        _jump.Initialize();
        _jump.JumpPower = jumpPower;
    }

    public override void UseAbilityTick()
    {
        _jump.JumpAbilityTick();
    }
}
