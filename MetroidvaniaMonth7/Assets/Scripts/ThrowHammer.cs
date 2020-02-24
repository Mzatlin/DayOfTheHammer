using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ThrowHammer : MonoBehaviour, IThrow
{
    public event Action OnThrow = delegate { };

    [SerializeField]
    GameObject hammer;
    [SerializeField]
    public float throwSpeed;
    Rigidbody2D _rigidBody;
    MovePhysics move;
    Vector2 movement;
    HammerAttack attack;
    bool isAbilityInUse = false;

    public float ThrowSpeed { get => throwSpeed; set => throwSpeed = value; }

    public bool IsAbilityInUse => isAbilityInUse;

    // Start is called before the first frame update

    public void InitializeThrow()
    {
        attack = GetComponent<HammerAttack>();
        move = GetComponent<MovePhysics>();
        InitializeProjectile();

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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Throw();
            //implement throwing sound
            FMODUnity.RuntimeManager.PlayOneShot("event:/Objects/Throw");
        }

        if (Vector3.Distance(transform.position, hammer.transform.position) > 5)
        {
            _rigidBody.velocity = Vector2.zero;
            isAbilityInUse = false;
        }
    }

    public void Throw()
    {
        if (CanThrow())
        {
            isAbilityInUse = true;
            OnThrow();
            hammer.transform.position = transform.position;
            hammer.SetActive(true);
            var finalDirection = attack.lastDirection.normalized; //Calculate Direction
            _rigidBody.velocity = new Vector2(finalDirection.x * throwSpeed, finalDirection.y * throwSpeed); //FireWeapon

        }
    }

    bool CanThrow() //CanFire
    {
        return true;
    }

}
