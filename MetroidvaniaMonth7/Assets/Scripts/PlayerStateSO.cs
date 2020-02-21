using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PlayerState")]
public class PlayerStateSO : ScriptableObject
{
    public bool isDead;
    public bool isStopped;

    public bool IsPlayerReady()
    {
        if(isDead || isStopped)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
