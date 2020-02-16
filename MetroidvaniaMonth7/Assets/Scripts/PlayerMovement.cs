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
    [SerializeField]
    bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask Ground;
    public LayerMask Box;
    LayerMask finalLayerMask;
    List<Collider2D> results;

    // Start is called before the first frame update
    void Start()
    {
        finalLayerMask = (1 << LayerMask.NameToLayer("Ground") | (1 << LayerMask.NameToLayer("Box")));
        jump = GetComponent<Jump>();
        move = GetComponent<MovePhysics>();
        playerScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, finalLayerMask);

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


