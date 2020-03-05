using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectOnStun : MonoBehaviour
{
    IStunnable stun;
    StunController controller;
    SpriteRenderer render;
    Color originalColor;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponentInChildren<SpriteRenderer>();
        originalColor = render.color;
        stun = GetComponent<IStunnable>();
        stun.OnStun += HandleStun;
        controller = GetComponent<StunController>();
        controller.OnEndStun += HandleEnd;
    }

    private void HandleStun()
    {
        render.color = Color.yellow;
    }

    private void HandleEnd()
    {
        render.color = originalColor;
    }

}
