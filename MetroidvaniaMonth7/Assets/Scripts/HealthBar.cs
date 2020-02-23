using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    IHealth health;
    IHittable hit;
    [SerializeField]
    Slider healthBar;
    float healthValue;
    // Start is called before the first frame update
    void Start()
    {
        hit = GetComponent<IHittable>();
        hit.OnHit += HandleHit;
        health = GetComponent<IHealth>();
        healthBar.image.color = Color.green;
    }

    private void HandleHit()
    {
        if(health.CurrentHealth < 2)
        {
            healthBar.image.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health.CurrentHealth;
    }
}
