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
    PlayerStateSO playerState;
    Rigidbody2D _rigidBody;
    MovePhysics move;
    Vector2 movement;
    HammerAttack attack;
    [SerializeField]
    bool isAbilityInUse = false;
    ICharacterMovement charMove;
    IVerticalDirection vertical;

    public float ThrowSpeed { get => throwSpeed; set => throwSpeed = value; }

    bool IAbility.IsAbilityInUse { get => isAbilityInUse; set => isAbilityInUse = value; }


    // Start is called before the first frame update
    public void InitializeThrow()
    {
        move = GetComponent<MovePhysics>();
        InitializeProjectile();
        charMove = GetComponent<ICharacterMovement>();
        vertical = GetComponent<IVerticalDirection>();

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
                //implement throwing sound
                FMODUnity.RuntimeManager.PlayOneShot("event:/Objects/Throw");
            }

        }
        if (Vector3.Distance(transform.position, hammer.transform.position) > 5 && hammer.activeInHierarchy)
        {
            _rigidBody.velocity = Vector2.zero;
            hammer.SetActive(false);
            OnAbilityEnd();
            isAbilityInUse = false;

        }

    }

    public void Throw()
    {
        if (CanThrow())
        {
            isAbilityInUse = true;
            OnAbilityStart();
            OnThrow();

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
    }

    bool CanThrow() //CanFire
    {
        return true;
    }

}
