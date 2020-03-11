using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField]
    PlayerHealthSO playerHealth;
    IHealth health;
    IHittable hit;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth.OnHealthAdded += HandleAddition;
        hit = GetComponent<IHittable>();
        hit.OnHit += HandleHit;
        health = GetComponent<IHealth>();
        playerHealth.maxHealth = (int)health.MaxHealth;
        playerHealth.currentHealth = (int)health.CurrentHealth;

    }

    private void HandleAddition()
    {
        health.CurrentHealth = playerHealth.currentHealth;
    }

    private void HandleHit()
    {
        if (health.CurrentHealth < 1)
            return;

        playerHealth.currentHealth -= 1;
    }

}
