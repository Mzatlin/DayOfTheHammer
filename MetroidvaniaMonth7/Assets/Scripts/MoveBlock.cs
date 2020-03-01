using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : HitBase
{
    [SerializeField]
    float moveXSpeed = 15f;
    [SerializeField]
    LayerMask staticLayer;
    Rigidbody2D rb;
    Vector2 targetPoint;
    Vector2 blockPoint;
    bool isHit = false;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
    }


    void Update()
    {
       // if(isHit && Mathf.Abs(rb.velocity.x) < 0.1f && Mathf.Abs(rb.velocity.y) <0.1f)
    //    {
     ////       rb.bodyType = RigidbodyType2D.Static;
    //        isHit = false;
     //   }    
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if((1 << collision.gameObject.layer & staticLayer) != 0){
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if ((1 << collision.gameObject.layer & staticLayer) != 0)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    protected override void HandleHitTransform(Transform trans)
    {
        isHit = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        targetPoint = Vector2.right;
        blockPoint = trans.position - transform.position;
        if (Vector2.Dot(targetPoint, blockPoint) < 0)
        {
            rb.velocity = new Vector2(moveXSpeed, 0);
        }
        if (Vector2.Dot(targetPoint, blockPoint) > 0)
        {
            rb.velocity = new Vector2(-moveXSpeed, 0);
        }
        base.HandleHitTransform(trans);

    }

    protected override void HandleHit(float damage)
    {
        isHit = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce(new Vector2(0, 35f / 1.4f), ForceMode2D.Impulse);
        base.HandleHit(damage);
    }



}
