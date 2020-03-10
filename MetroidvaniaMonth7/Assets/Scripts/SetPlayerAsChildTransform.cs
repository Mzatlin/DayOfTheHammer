using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerAsChildTransform : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
