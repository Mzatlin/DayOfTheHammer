using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerExtensionMethods 
{

    public static void ResetPlayerState(this PlayerStateSO playerState)
    {
        playerState.isDead = false;
        playerState.isStopped = false;
    }

    public static void KillPlayer(this PlayerStateSO playerState) => playerState.isDead = true;

}
