using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveOnCameraEntry : MonoBehaviour
{
    [SerializeField]
    GameObject minimapPiece;
    CameraRoomTransition transition;
    // Start is called before the first frame update
    void Start()
    {
        transition = GetComponent<CameraRoomTransition>();
        transition.OnRoomChange += HandleRoomChange;
        if(minimapPiece == null)
        {
            Debug.Log("No Minimap Piece Assigned");
        }
    }

    void HandleRoomChange()
    {
        minimapPiece.SetActive(true);
    }
}
