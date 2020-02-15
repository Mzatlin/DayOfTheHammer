﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    [SerializeField]
    float _jumpPower = 10f;
    [SerializeField]
    float fallMultiplier = 2.5f;
    [SerializeField]
    float lowJumpMultiplier = 2f;

    Rigidbody2D _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_rigidbody.velocity.y < 0)
        {
            _rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }
        else if (_rigidbody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            _rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
        }
    }

    public void JumpMove()
    {
        _rigidbody.velocity = Vector2.up * _jumpPower;
    }
}
