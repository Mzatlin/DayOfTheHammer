using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectOnStun : MonoBehaviour
{
    IStunnable stun;
    SpriteRenderer render;
    Color originalColor;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponentInChildren<SpriteRenderer>();
        originalColor = render.color;
        stun = GetComponent<IStunnable>();
        stun.OnStun += HandleStun;
        stun.OnEndStun += HandleEnd;
    }

    private void HandleStun()
    {
        render.color = Color.blue;
    }

    private void HandleEnd()
    {
        render.color = originalColor;
    }

}
