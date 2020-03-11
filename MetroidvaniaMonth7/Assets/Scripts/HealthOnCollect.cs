using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOnCollect : CollectBase
{
    [SerializeField]
    PlayerHealthSO health;
    [SerializeField]
    int healthAmount;
    public event Action OnCollect = delegate { };

    protected override void HandleCollection()
    {
        if (health.currentHealth == health.maxHealth)
            return;
        base.HandleCollection();
        health.AddHealth(healthAmount);
        gameObject.SetActive(false);
    }

}
