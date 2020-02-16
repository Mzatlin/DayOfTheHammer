using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitOnTouch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        var hit = collision.GetComponent<IHittable>();
        if(hit != null)
        {
            hit.ProcessHit();
        }
    }
}
