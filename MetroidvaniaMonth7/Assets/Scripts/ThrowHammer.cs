using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ThrowHammer : MonoBehaviour, IThrow, IAbility
{
    public event Action OnThrow = delegate { };
    public event Action OnAbilityStart = delegate { };
    public event Action OnAbilityEnd = delegate { };

    [SerializeField]
    GameObject hammer;
    [SerializeField]
    public float throwSpeed;
    [SerializeField]
    float throwDelay = 0.1f;
    [SerializeField]
    PlayerStateSO playerState;
    Rigidbody2D _rigidBody;
    MovePhysics move;
    Vector2 movement;
    HammerAttack attack;
    [SerializeField]
    bool isAbilityInUse = false;
    ICharacterMovement charMove;
    IVerticalDirection vertical;
    GrappleOnTouch grapple;
    Animator animator;

    public float ThrowSpeed { get => throwSpeed; set => throwSpeed = value; }

    bool IAbility.IsAbilityInUse { get => isAbilityInUse; set => isAbilityInUse = value; }


    // Start is called before the first frame update
    public void InitializeThrow()
    {
        move = GetComponent<MovePhysics>();
        InitializeProjectile();
        charMove = GetComponent<ICharacterMovement>();
        vertical = GetComponent<IVerticalDirection>();
        animator = GetComponentInChildren<Animator>();
        grapple = hammer.GetComponent<GrappleOnTouch>();
        grapple.OnGrapple += HandleGrapple;

    }

    private void HandleGrapple(Transform obj)
    {
         OnAbilityEnd();
        isAbilityInUse = false;
    }

    void InitializeProjectile()
    {
        if (hammer != null)
        {
            _rigidBody = hammer.GetComponent<Rigidbody2D>();
            hammer.SetActive(false);
        }
    }


    public void ThrowAttackTick()
    {
        if (isAbilityInUse || playerState.IsPlayerReady())
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {

                Throw();

            }

            if (Vector3.Distance(transform.position, hammer.transform.position) > 5 && hammer.activeInHierarchy)
            {
                _rigidBody.velocity = Vector2.zero;
                hammer.SetActive(false);
                OnAbilityEnd();
                isAbilityInUse = false;
                animator.SetBool("IsThrowing", false);
            }
        }
    }

    public void Throw()
    {
        if (CanThrow())
        {
            //implement throwing sound
            FMODUnity.RuntimeManager.PlayOneShot("event:/Objects/Throw");
            isAbilityInUse = true;
            OnAbilityStart();
            OnThrow();
            animator.SetBool("IsThrowing", true);
            StartCoroutine(ThrowDelay());
         
        }
    }

    void SpawnHammer()
    {
        hammer.transform.position = transform.position;
        hammer.SetActive(true);
        if (Mathf.Abs(vertical.MoveDirectionY.y) < 0.1f)
        {
            var finalDirection = charMove.GetLasLoggedDirection().normalized; //Calculate Direction
            _rigidBody.velocity = new Vector2(finalDirection.x * throwSpeed, finalDirection.y * throwSpeed); //FireWeapon
        }
        else
        {
            var finalDirection = vertical.MoveDirectionY.normalized; //Calculate Direction
            _rigidBody.velocity = new Vector2(finalDirection.x * throwSpeed, finalDirection.y * throwSpeed); //FireWeapon
        }

    }

    IEnumerator ThrowDelay()
    {
        yield return new WaitForSeconds(throwDelay);
        SpawnHammer();
    }

    bool CanThrow() //CanFire
    {
        if (!isAbilityInUse)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
