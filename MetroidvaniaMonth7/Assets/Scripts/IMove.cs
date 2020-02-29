using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove 
{
    float MovementSpeed { get; set; }
    Vector2 MoveDirectionX { get; set; }
    void MoveX(float _movDirectionX);
}
