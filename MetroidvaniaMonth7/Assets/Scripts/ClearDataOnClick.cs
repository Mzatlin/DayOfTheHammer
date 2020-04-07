using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearDataOnClick : OnClickListenerBase
{
    [SerializeField]
    SaveSystemSO saveSystem;

    public override void HandleClickEvent()
    {
        saveSystem.ClearData();
    }
}
