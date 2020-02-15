using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovePhysics : MonoBehaviour
{
    [SerializeField]
    float _movementSpeed = 10f;

    Rigidbody2D _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void MoveX(float _moveDirX)
    {
        _rigidbody.velocity = new Vector2(_moveDirX * _movementSpeed, _rigidbody.velocity.y);
    }

}
