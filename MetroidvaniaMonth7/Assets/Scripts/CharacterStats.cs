using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour, ICharacterMovement
{

    IMove movement;
    [SerializeField]
    Vector2 _startingDirection;
    Vector2 _lastLoggedDirection;
    public Vector2 StartingDirection => _startingDirection;

    public Vector2 LastLoggedDirection { get => _lastLoggedDirection;}


    // Start is called before the first frame update
    void Awake()
    {
        movement = GetComponent<IMove>();
        if(_startingDirection == null)
        {
            _startingDirection = Vector2.right;
        }
        _lastLoggedDirection = _startingDirection;
    }



    public Vector2 GetCurrentMoveDirection()
    {
        if(movement.MoveDirection == Vector2.zero)
        {
            return GetLasLoggedDirection();
        }

        else
        {
            _lastLoggedDirection = movement.MoveDirection;
            return movement.MoveDirection;
        }

    }

    public Vector2 GetLasLoggedDirection()
    {
            return _lastLoggedDirection;
    }

    void Update()
    {
        movement.MoveDirection = GetCurrentMoveDirection();
    }

}
