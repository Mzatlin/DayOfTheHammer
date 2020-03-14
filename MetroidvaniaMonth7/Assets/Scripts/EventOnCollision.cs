using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventOnCollision : MonoBehaviour, IEventOnCollision
{
    public event Action OnTrigger = delegate { };
    [SerializeField]
    LayerMask playerLayer;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & playerLayer) != 0)
        {
            OnTrigger();
        }
    }
}
