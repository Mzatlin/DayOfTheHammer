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
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }


    protected override void HandleHit()
    {
        base.HandleHit();
        rb.velocity = new Vector2(moveX, 0);
    }

}
