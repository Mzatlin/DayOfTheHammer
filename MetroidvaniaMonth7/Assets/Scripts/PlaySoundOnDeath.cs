using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnDeath : MonoBehaviour
{

    [FMODUnity.EventRef]
    public string deathPath;
    IHealth health;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<IHealth>();
        health.OnDie += HandleDie;
    }

    private void HandleDie()
    {
        FMODUnity.RuntimeManager.PlayOneShot(deathPath, transform.position);
    }

}
