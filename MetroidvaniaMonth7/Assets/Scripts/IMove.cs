using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove 
{
    float MovementSpeed { get; set; }
    Vector2 MoveDirection { get; set; }
    void MoveX(float _movDirectionX);
    void MoveY(float _moveDirectionY);
}
