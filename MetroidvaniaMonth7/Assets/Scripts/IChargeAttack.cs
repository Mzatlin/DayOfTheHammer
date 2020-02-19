using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChargeAttack 
{
    void HammerChargeTick();
    void InitializeCharge();
    float HammerRadius { get; set; }
}
