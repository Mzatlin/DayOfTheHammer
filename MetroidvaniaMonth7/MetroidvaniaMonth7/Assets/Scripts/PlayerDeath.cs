using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : DeathBase
{
    [SerializeField]
    PlayerStateSO playerState;
    // Start is called before the first frame update
    protected override void HandleDie()
    {
        playerState.KillPlayer();
        StartCoroutine(DieDelay());
    }


    IEnumerator DieDelay()
    {
        yield return new WaitForSeconds(.1f);
        Debug.Log("Player Died");
    }
}
