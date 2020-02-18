using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SwitchController : MonoBehaviour
{

    public event Action OnTrigger = delegate { };
    public bool isTriggered;

    void OnTriggerEnter2D(Collider2D collision)
    {
        var box = collision.GetComponent<IHittable>();
        if(box != null)
        {
            isTriggered = true;
            OnTrigger();
        }
    }
}
