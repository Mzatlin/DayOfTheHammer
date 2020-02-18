using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/ThrowAbility")]
public class NewBehaviourScript : AbilitySO
{
    [SerializeField]
    GameObject hammer;
    [SerializeField]
    float throwSpeed;
    Rigidbody2D _rigidBody;
    MovePhysics move;
    Vector2 movement;
    HammerAttack attack;

    public override void Initialize(GameObject obj)
    {
        throw new System.NotImplementedException();
    }

    public override void UseAbilityTick()
    {
        throw new System.NotImplementedException();
    }
}
