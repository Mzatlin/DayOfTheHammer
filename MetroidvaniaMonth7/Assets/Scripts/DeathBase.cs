using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DeathBase : MonoBehaviour
{
    IHealth health;
    SpriteRenderer sprite;
    Collider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        collider.enabled = true;
        sprite = GetComponentInChildren<SpriteRenderer>();
        sprite.enabled = true;
        health = GetComponent<IHealth>();
        health.OnDie += HandleDie;
    }

    protected virtual void HandleDie()
    {
        sprite.enabled = false;
        collider.enabled = false;
    }
}
