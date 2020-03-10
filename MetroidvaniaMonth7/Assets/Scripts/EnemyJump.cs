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

    public float JumpPower { get => jumpPower; set => jumpPower = value; }

    public bool IsAbilityInUse => throw new System.NotImplementedException();

    // Start is called before the first frame update
    public void Start()
    {
        finalLayerMask = (1 << LayerMask.NameToLayer("Ground") | (1 << LayerMask.NameToLayer("Box")));
        jump = GetComponent<Jump>();
    }

    // Update is called once per frame
    public void Update()
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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Jump");

=======

           // FMODUnity.RuntimeManager.PlayOneShot("event:/Spring", GetComponent<Transform> ().position);
>>>>>>> Stashed changes
=======

            //FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Jump");
>>>>>>> Stashed changes
        }

        if (isGrounded != wasGrounded)
        {
            wasGrounded = !wasGrounded;
;
            if (isGrounded == false)
            {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
              FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Landed");
=======
               // FMODUnity.RuntimeManager.PlayOneShot("event:/SpringLand", GetComponent<Transform>().position);
>>>>>>> Stashed changes
=======
             //   FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Landed");
>>>>>>> Stashed changes
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

    public void JumpAbilityTick()
    {
        throw new System.NotImplementedException();
    }

    public void Initialize()
    {
        throw new System.NotImplementedException();
    }
}
