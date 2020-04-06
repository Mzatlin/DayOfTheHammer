using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCheckPointData : ClearDataBase
{
    [SerializeField]
    CheckpointSO checkpoint;
    protected override void HandleClearData()
    {
        checkpoint.checkpointLocation = Vector3.zero;
    }

}
