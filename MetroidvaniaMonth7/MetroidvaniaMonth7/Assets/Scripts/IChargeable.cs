using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IChargeable  
{
    float HoldDownTime { get; }
    float TimeToCharge { get; set; }
}
