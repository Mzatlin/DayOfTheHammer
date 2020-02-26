using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HitOnTouch : MonoBehaviour
{
    [SerializeField]
    LayerMask finalmask;

    void Start()
    {
        //  mask = LayerMask.GetMask("Grapple");
        if (finalmask == 0)
        {
            Debug.Log("Missing LayerMask!");
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        var hit = collision.GetComponent<IHittable>();
        if (hit != null && (1 << collision.gameObject.layer & finalmask) != 0)
        {
            hit.ProcessHit();
            //Debug.Log("HIT");
        }
    }
}

