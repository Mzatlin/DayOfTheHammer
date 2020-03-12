using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SaveSystem")]
public class SaveSystemSO : ScriptableObject
{
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
        checkPoint.checkpointLocation = Vector3.zero;
    }
}
