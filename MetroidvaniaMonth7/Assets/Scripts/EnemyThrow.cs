using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrow : MonoBehaviour, IThrow
{

    [SerializeField]
    float throwSpeed;
    [SerializeField]
    GameObject hammer;
    Rigidbody2D _rigidBody;

    public float ThrowSpeed { get => throwSpeed; set => throwSpeed = value; }

    public bool IsAbilityInUse => throw new System.NotImplementedException();

    public void InitializeThrow()
    {
        if (hammer != null)
        {
            _rigidBody = hammer.GetComponent<Rigidbody2D>();
            hammer.SetActive(false);
        }
    }

    public void ThrowAttackTick()
    {
        throw new System.NotImplementedException();
    }
 }
