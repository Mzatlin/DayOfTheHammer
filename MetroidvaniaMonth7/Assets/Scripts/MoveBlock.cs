using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : HitBase
{
    [SerializeField]
    GameObject target;
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


    protected override void HandleHit(float damage)
    {
        targetPoint = Vector2.right;
        blockPoint = target.transform.position - transform.position;
        Debug.Log(Vector2.Dot(targetPoint, blockPoint));
        if (Vector2.Dot(targetPoint, blockPoint) < 0)
        {
            Debug.Log("To the right");
        }
        if (Vector2.Dot(targetPoint, blockPoint) > 0)
        {
            Debug.Log("To the left");
        }
        base.HandleHit(damage);
        rb.velocity = new Vector2(moveX, 0);
    }

}
