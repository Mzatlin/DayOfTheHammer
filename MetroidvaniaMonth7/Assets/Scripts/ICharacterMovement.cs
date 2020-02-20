using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterMovement
{
    Vector2 StartingDirection { get; }
    Vector2 LastLoggedDirection { get; }
    Vector2 GetCurrentMoveDirection();
    Vector2 GetLasLoggedDirection();
}
