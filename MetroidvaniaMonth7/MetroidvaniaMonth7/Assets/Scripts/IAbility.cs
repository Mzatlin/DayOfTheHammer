using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IAbility 
{
    event Action OnAbilityStart;
    event Action OnAbilityEnd;
}
