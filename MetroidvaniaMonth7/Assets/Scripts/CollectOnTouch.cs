using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectOnTouch : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        var collect = collision.GetComponent<ICollectable>();
        if(collect != null)
        {
            collect.ProcessCollection();
        }
    }
}
