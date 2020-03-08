using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraRoomTransition : MonoBehaviour
{
    public event Action OnRoomChange = delegate { };

    [SerializeField]
    GameObject camera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            OnRoomChange();
            camera.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            camera.SetActive(false);
        }
    }
}
