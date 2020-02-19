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

    public float ThrowSpeed { get => throwSpeed; set => throwSpeed = value; }

    // Start is called before the first frame update

    public void InitializeThrow()
    {
        attack = GetComponent<HammerAttack>();
        move = GetComponent<MovePhysics>();
        if (hammer != null)
        {
            _rigidBody = hammer.GetComponent<Rigidbody2D>();
            hammer.SetActive(false);
            hammer.GetComponent<HitOnTouch>().OnTouch += HandleTouch;
        }
    }

    private void HandleTouch(Transform obj)
    {
        transform.position = obj.transform.position;
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
        }
    }

    public void Throw()
    {
        if (CanThrow())
        {
            OnThrow();
            hammer.transform.position = transform.position;
            hammer.SetActive(true);
            var finalDirection = attack.lastDirection.normalized;
            _rigidBody.velocity = new Vector2(finalDirection.x * throwSpeed, finalDirection.y * throwSpeed);

        }
    }

    bool CanThrow()
    {
        return true;
    }

}
