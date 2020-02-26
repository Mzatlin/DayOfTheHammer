using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IChargeAttack 
{
    void HammerChargeTick();
    void InitializeCharge();
    float HammerRadius { get; set; }
    bool IsAbilityInUse { get; }
}
