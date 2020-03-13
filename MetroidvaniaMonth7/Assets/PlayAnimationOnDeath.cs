using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationOnDeath : MonoBehaviour
{
    Animator animate;
    IHealth health;
    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponentInChildren<Animator>();
        health = GetComponent<IHealth>();
        health.OnDie += HandleDie;
    }

    private void HandleDie()
    {
        if(animate != null)
        {
            animate.SetBool("IsDead", true);
        }
    }

}
