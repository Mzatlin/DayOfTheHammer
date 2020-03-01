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
        rb.bodyType = RigidbodyType2D.Static;
    }


    void Update()
    {
        if(Mathf.Abs(rb.velocity.x) < 0.1f && Mathf.Abs(rb.velocity.y) <0.1f)
        {
            rb.bodyType = RigidbodyType2D.Static;
        }    
    }

    protected override void HandleHitTransform(Transform trans)
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
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

    protected override void HandleHit(float damage)
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce(new Vector2(0, 35f / 1.4f), ForceMode2D.Impulse);
        base.HandleHit(damage);
    }



}
