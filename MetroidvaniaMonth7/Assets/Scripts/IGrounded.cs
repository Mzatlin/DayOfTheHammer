using UnityEngine;
using System;

public interface IGrounded
{
    bool IsGrounded { get; }
    LayerMask GroundLayerMask { get; }
}