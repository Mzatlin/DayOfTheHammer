using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDeath : DeathBase
{
    protected override void HandleDie()
    {
        base.HandleDie();
        StartCoroutine(DieDelay());
    }

    IEnumerator DieDelay()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
