using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerStatsOnStart : MonoBehaviour
{
    [SerializeField]
    PlayerStateSO playerState;
    void Awake()
    {
        playerState.ResetPlayerState();
    }
}
