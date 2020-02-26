using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDeath : DeathBase
{

    protected override void HandleDie()
    {
        base.HandleDie();
        StartCoroutine(DieDelay());

        //death sound. not sure if this should be triggered with the delay or before
        FMODUnity.RuntimeManager.PlayOneShot("event:/Enemy/Enemy-Dead");

    }

    IEnumerator DieDelay()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
