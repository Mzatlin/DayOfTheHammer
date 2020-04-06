using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClearDataBase : MonoBehaviour
{
    [SerializeField]
    protected SaveSystemSO saveSystem;

    void Start()
    {
        if(saveSystem != null)
        {
            saveSystem.OnClearData += HandleClearData;
        }    
    }

    protected abstract void HandleClearData();
}
