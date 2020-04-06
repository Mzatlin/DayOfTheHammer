using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "SaveSystem")]
public class SaveSystemSO : ScriptableObject
{
    public event Action OnClearData = delegate { };
    public CheckpointSO checkPoint;

    public bool CheckIfSaved()
    {
        if(checkPoint.checkpointLocation == Vector3.zero)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void ClearData()
    {
        OnClearData();
    }
}
