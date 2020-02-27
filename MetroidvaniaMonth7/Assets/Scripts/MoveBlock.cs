using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : HitBase
{
    [SerializeField]
    float moveX = 15f;
    Rigidbody2D rb;
    [SerializeField]
    Vector2 targetPoint;
    [SerializeField]
    Vector2 blockPoint;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }


    protected override void HandleHitTransform(Transform trans)
    {
        targetPoint = Vector2.right;
        blockPoint = trans.position - transform.position;
        if (Vector2.Dot(targetPoint, blockPoint) < 0)
        {
            rb.velocity = new Vector2(moveX, 0);
        }
        if (Vector2.Dot(targetPoint, blockPoint) > 0)
        {
            rb.velocity = new Vector2(-moveX, 0);
        }
        base.HandleHitTransform(trans);

    }

}
