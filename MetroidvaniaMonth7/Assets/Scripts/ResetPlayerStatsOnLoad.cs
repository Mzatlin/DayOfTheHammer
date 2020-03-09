using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerStatsOnLoad : MonoBehaviour
{
    [SerializeField]
    PlayerStateSO player;
    // Start is called before the first frame update
    void Start()
    {
        player.ResetPlayerState();
        Time.timeScale = 1;
    }

}
