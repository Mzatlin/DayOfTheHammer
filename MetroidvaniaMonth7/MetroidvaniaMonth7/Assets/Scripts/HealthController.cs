using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : HitBase, IHealth
{
    public event Action OnDie = delegate { };

    [SerializeField]
    float currentHealth = 1f;
    [SerializeField]
    float maxHealth = 1f;
    [SerializeField]
    bool isDead = false;

    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public bool IsDead { get => isDead; set => isDead = value; }

    //health is decremented and death is handled here. Unless already dead, the hit event will be triggered. 
    protected override void HandleHit(float damage)
    {
        if (isDead) //also check if CanHit from ICanHit
        {
            return;
        }
        base.HandleHit(damage);
        currentHealth -= damage;

        if (currentHealth == 2)
            FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Player-Hit/First");

        if (currentHealth == 1)
            FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Player-Hit/Second");

        if (currentHealth < 1)
        {
            isDead = true;
            OnDie();
            FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Player-Hit/Death");

        }
    }

}
