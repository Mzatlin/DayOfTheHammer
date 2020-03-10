using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CheckPoint")]
public class CheckpointSO : ScriptableObject
{
    public Vector3 checkpointLocation;
    public Transform startingLocation;
}
