using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBase : MonoBehaviour, ICollectable
{
    public event Action OnCollect = delegate { };

    public void ProcessCollection()
    {
        HandleCollection();
    }

    protected virtual void HandleCollection()
    {
        OnCollect();
    }

}
