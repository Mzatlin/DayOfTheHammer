using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    PlayerStateSO playerState;
    IMove move;
    public bool isFacingRight = true;
    private float moveX;
    Vector2 playerScale;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<IMove>();
        playerScale = transform.localScale;
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerState.IsPlayerReady())
        {
            MovePlayer();
        }
        else
        {
            move.MoveX(0f);
            animator.SetFloat("PlayerMoveX",0f);
        }

    }

    void MovePlayer()
    {
        moveX = Input.GetAxis("Horizontal");

        move.MoveX(moveX);
        animator.SetFloat("PlayerMoveX", Mathf.Abs(moveX));

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
      //  FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Flip");


    }

}


