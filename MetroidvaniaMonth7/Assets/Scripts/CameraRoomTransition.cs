using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoomTransition : MonoBehaviour
{
    [SerializeField]
    GameObject camera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
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
