using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOnHit : HitBase
{
    SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponentInChildren<SpriteRenderer>();
    }

    protected override void HandleHit()
    {
        base.HandleHit();
        render.enabled = false;
        gameObject.SetActive(false);
    }
}

