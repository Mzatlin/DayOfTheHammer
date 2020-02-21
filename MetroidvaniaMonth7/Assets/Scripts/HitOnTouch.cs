using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HitOnTouch : MonoBehaviour
{
    public event Action<Transform> OnTouch = delegate { };

    [SerializeField]
    LayerMask mask;

    void Start()
    {
        mask = LayerMask.GetMask("Grapple");
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        var hit = collision.GetComponent<IHittable>();
        if(hit != null)
        {
            hit.ProcessHit();
            var result = Physics2D.OverlapCircle(transform.position, 1f, mask);
            if(result != null)
            {
                OnTouch(collision.transform);
            }

        }
    }
}
