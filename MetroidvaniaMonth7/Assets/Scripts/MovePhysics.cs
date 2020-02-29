using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovePhysics : MoveBase
{
    Rigidbody2D _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
        

    public override void MoveX(float _movDirectionX)
    {
        moveDirection = new Vector2(_movDirectionX, 0);
        _rigidbody.velocity = new Vector2(_movDirectionX * moveSpeed, _rigidbody.velocity.y);
    }
}
