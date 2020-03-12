using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearDataOnClick : MonoBehaviour
{
    [SerializeField]
    SaveSystemSO saveSystem;

    public void OnClickClear()
    {
        saveSystem.ClearData();
    }
}
