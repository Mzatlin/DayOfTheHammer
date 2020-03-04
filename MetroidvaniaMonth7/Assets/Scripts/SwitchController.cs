using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SwitchController : MonoBehaviour
{
    IMoveBlock move;
    public event Action OnTrigger = delegate { };
    public bool isTriggered;

    void OnTriggerEnter2D(Collider2D collision)
    {
        move = collision.GetComponent<IMoveBlock>();
        if(move != null)
        {
            isTriggered = true;
            OnTrigger();
        }
    }
}
