using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerAsChildTransform : MonoBehaviour,ISetParent
{
    [SerializeField]
    private bool isParented = false;

    public bool IsParented => isParented;

    void OnCollisionEnter2D(Collision2D collision)
    {
        isParented = true;
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isParented = false;
        collision.transform.SetParent(null);
    }
}
