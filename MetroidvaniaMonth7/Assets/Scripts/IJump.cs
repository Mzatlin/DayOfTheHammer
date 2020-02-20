using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJump 
{
    void Jump();
    float JumpPower { get; set; }
    void JumpAbilityTick();
    void Initialize();
}
