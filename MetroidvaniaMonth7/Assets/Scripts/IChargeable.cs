using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IChargeable  
{
    event Action OnChargeBegin;
    event Action OnChargeEnd;
    float HoldDownTime { get; }
    float TimeToCharge { get; set; }
}
