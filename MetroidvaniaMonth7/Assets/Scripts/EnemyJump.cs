using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour, IJump
{
    [HideInInspector]
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

    public float JumpPower { get => jumpPower; set => jumpPower = value; }

    // Start is called before the first frame update
    public void Initialize()
    {
        finalLayerMask = (1 << LayerMask.NameToLayer("Ground") | (1 << LayerMask.NameToLayer("Box")));
        jump = GetComponent<Jump>();
    }

    // Update is called once per frame
    public void JumpAbilityTick()
    {
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

    bool CanJump()
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
}
