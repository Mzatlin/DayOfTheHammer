using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IHealth
{
    event Action OnDie;
    float CurrentHealth { get; set; }
    float MaxHealth { get; set; }
    bool IsDead { get; set; }
}
