using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ReloadLastCheckPoint : MonoBehaviour
{
    [SerializeField]
    CheckpointSO checkpoint;
    [SerializeField]
    GameObject player;

    private void Awake()
    {
        LoadCheckPoint();
    }
    // Start is called before the first frame update
    public void LoadCheckPoint()
    {
        if (checkpoint.checkpointLocation == Vector3.zero)
        {
            SetPlayerLocation(checkpoint.startingLocation.position);
        }
        else
        {
            SetPlayerLocation(checkpoint.checkpointLocation);
        }
    }

    void SetPlayerLocation(Vector3 loc)
    {
        player.transform.position = loc;
    }
}
