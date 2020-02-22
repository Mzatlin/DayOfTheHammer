using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GrappleOnTouch : MonoBehaviour
{
    public event Action<Transform> OnGrapple = delegate { };

    [SerializeField]
    LayerMask finalmask;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
     {
        InitiateGrapple(collision);
     }


    void InitiateGrapple(Collider2D _collision)
    {
        var result = Physics2D.OverlapCircle(transform.position, 1f, finalmask);
        if (result != null)
        {
            OnGrapple(_collision.transform);
        }
    }

}
