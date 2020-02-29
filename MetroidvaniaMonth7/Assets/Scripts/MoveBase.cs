using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveBase : MonoBehaviour, IMove
{

    [SerializeField]
    protected float moveSpeed;
    protected Vector2 moveDirection;

    public Vector2 MoveDirectionX { get => moveDirection; set => moveDirection = value; }
    public float MovementSpeed { get => moveSpeed; set => moveSpeed = value; }

    public abstract void MoveX(float _movDirectionX);
}
