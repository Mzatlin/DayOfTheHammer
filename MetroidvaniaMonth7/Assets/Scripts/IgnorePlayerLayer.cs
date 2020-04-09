using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorePlayerLayer : MonoBehaviour
{
    [SerializeField]
    LayerMask ignoreMask;
    // bool iscolliding;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((1 << collision.gameObject.layer & ignoreMask) != 0)
        {
            Physics2D.IgnoreLayerCollision(9, 11, Vector2.Distance(collision.transform.position, transform.position) < 3f);
            StartCoroutine(HitDelay());
        }
    }

    IEnumerator HitDelay()
    {
        yield return new WaitForSeconds(1f);
        Physics2D.IgnoreLayerCollision(9, 11, false);
    }

}
