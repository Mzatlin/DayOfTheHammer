using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IThrow 
{
    void ThrowAttackTick();
    void InitializeThrow();
    float ThrowSpeed { get; set; }
    bool IsAbilityInUse { get;  }
}
