using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    MovePhysics move;
    Jump jump;
    public bool isFacingRight = true;
    private float moveX;
    Vector2 playerScale;
    Rigidbody2D rigidbody;
    [SerializeField]
    bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask Ground;

    // Start is called before the first frame update
    void Start()
    {
        jump = GetComponent<Jump>();
        move = GetComponent<MovePhysics>();
        rigidbody = GetComponent<Rigidbody2D>();
        playerScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, Ground);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jump.JumpMove();
        }

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
    }
}


