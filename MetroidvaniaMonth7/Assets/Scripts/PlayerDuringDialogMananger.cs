using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDuringDialogMananger : MonoBehaviour
{
    [SerializeField]
    PlayerStateSO playerState;
    IActiveDialog active;
    IDialogEnd end;

    // Start is called before the first frame update
    void Start()
    {
        active = GetComponent<IActiveDialog>();
        active.OnDialogStart += HandleDialogStart;
        end = GetComponent<IDialogEnd>();
        end.OnDialogEnd += HandleDialogEnd;
    }

    private void HandleDialogEnd()
    {
        playerState.isStopped = false;
    }

    private void HandleDialogStart()
    {
        playerState.isStopped = true;
    }

}
