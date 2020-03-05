using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour,IJump
{
    [SerializeField]
    public float jumpPower = 5f;
    [SerializeField]
    public bool isGrounded;
    float timeBeforeJump = 0f;
    [SerializeField]
    float jumpRate = .5f;
    bool wasGrounded = true;
    Jump jump;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask Ground;
    public LayerMask Box;
    LayerMask finalLayerMask;
    Animator animator;
    Rigidbody2D rb;

    public float JumpPower { get => jumpPower; set => jumpPower = value; }

    public bool IsAbilityInUse => throw new System.NotImplementedException();

    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        finalLayerMask = (1 << LayerMask.NameToLayer("Ground") | (1 << LayerMask.NameToLayer("Box")));
        jump = GetComponent<Jump>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (!isGrounded && rb.velocity.y < 0)
        {
            animator.SetBool("IsFalling", true);
            animator.SetBool("CanJump", false);
        }
        else
        {
            animator.SetBool("IsFalling", false);
        }
            if (CanJump())
        {
            Jump();
        }

    }

    public void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, finalLayerMask);
        if (isGrounded)
        {
            animator.SetBool("CanJump", true);
            jump.JumpMove(jumpPower);

            FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Jump");
        }

        if (isGrounded != wasGrounded)
        {
            wasGrounded = !wasGrounded;
            if (isGrounded == true)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Landed");
            }

        }
    }

    public bool CanJump()
    {
        if(Time.time >= timeBeforeJump)
        {
            timeBeforeJump = Time.time + jumpRate;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void JumpAbilityTick()
    {
        throw new System.NotImplementedException();
    }

    public void Initialize()
    {
        throw new System.NotImplementedException();
    }
}
