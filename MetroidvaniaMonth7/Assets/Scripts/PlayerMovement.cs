﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    IMove move;
    public bool isFacingRight = true;
    private float moveX;
    Vector2 playerScale;


    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<IMove>();
        playerScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        moveX = Input.GetAxis("Horizontal");

        move.MoveX(moveX);

        if (moveX < 0.0f && isFacingRight == false)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && isFacingRight == true)
        {
            FlipPlayer();
        }
        
    }

    void FlipPlayer()
    {
        isFacingRight = !isFacingRight;
        playerScale.x *= -1;
        transform.localScale = playerScale;
        //maybe add a flip direction sound
        FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Flip");


    }

}


