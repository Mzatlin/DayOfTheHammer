using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface ICollectable 
{
    event Action OnCollect;
    void ProcessCollection();
}
