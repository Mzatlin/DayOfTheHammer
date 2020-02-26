using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOnDeath : EnableCanvasBase
{
    IHealth health;
    // Start is called before the first frame update
    void Awake()
    {
        SetCanvasInactive();
        health = GetComponent<IHealth>();
        health.OnDie += HandleDie;
    }

    private void HandleDie()
    {
        SetCanvasActive();
    }
}
