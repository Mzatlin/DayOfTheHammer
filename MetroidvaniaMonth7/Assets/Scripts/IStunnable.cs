using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public interface IStunnable
{
    event Action OnStun;
    event Action OnEndStun;
    bool IsStunned { get; set; }
}
