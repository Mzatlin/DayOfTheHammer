using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class MoveCollider : MoveBase
{
    public override void MoveX(float _movDirectionX)
    {
        transform.position += new Vector3(_movDirectionX*moveSpeed, 0,0);
    }

    public override void MoveY(float _moveDirectionY)
    {
        throw new System.NotImplementedException();
    }

}
