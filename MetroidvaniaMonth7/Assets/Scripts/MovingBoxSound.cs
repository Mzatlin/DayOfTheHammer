using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBoxSound : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Box2" || collision.gameObject.name == "Box")
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Objects/FallingBox", GetComponent<Transform>().position);
        }

    }






}
