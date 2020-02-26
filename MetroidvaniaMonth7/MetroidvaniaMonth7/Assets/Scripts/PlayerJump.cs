using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour, IJump
{
    [HideInInspector]
    public float jumpPower = 5f;
    [SerializeField]
    bool isGrounded;
    bool wasGrounded = true;
    Jump jump;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask Ground;
    public LayerMask Box;
    LayerMask finalLayerMask;
    bool isAbilityInUse = false;

    public float JumpPower { get => jumpPower; set => jumpPower = value; }

    public bool IsAbilityInUse => isAbilityInUse;

    // Start is called before the first frame update
    public void Initialize()
    {
        finalLayerMask = (1 << LayerMask.NameToLayer("Ground") | (1 << LayerMask.NameToLayer("Box")));
        jump = GetComponent<Jump>();
    }

    // Update is called once per frame
    public void JumpAbilityTick()
    {
        Jump();
    }

    public void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, finalLayerMask);

        if (Input.GetButtonDown("Jump") && isGrounded)
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
}

