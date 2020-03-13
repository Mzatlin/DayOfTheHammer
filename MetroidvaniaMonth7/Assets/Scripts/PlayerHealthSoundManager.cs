using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSoundManager : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string health1;
    [FMODUnity.EventRef]
    public string health2;
    [FMODUnity.EventRef]
    public string playerDeathSound;

    IHealth health;
    IHittable hit;
    Animator animate;
    // Start is called before the first frame update
    void Start()
    {
        hit = GetComponent<IHittable>();
        hit.OnHit += HandleHit;
        health = GetComponent<IHealth>();
        health.OnDie += HandleDie;
        animate = GetComponentInChildren<Animator>();
    }

    private void HandleHit()
    {
        if (health.CurrentHealth < 1)
            return;

        if(health.CurrentHealth >= 2)
        {
            FMODUnity.RuntimeManager.PlayOneShot(health1, transform.position);
        }
        else if(health.CurrentHealth == 1)
        {
            FMODUnity.RuntimeManager.PlayOneShot(health2, transform.position);
        }
    }

    private void HandleDie()
    {
        animate.SetBool("IsDead", true);
        FMODUnity.RuntimeManager.PlayOneShot(playerDeathSound, transform.position);
    }


}
