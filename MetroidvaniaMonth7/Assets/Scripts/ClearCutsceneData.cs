using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCutsceneData : ClearDataBase
{
    [SerializeField]
    GameStateSO game;

    protected override void HandleClearData()
    {
        game.isOpeningComplete = false;
    }


}
