using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RaiseEventOnClick : MonoBehaviour, IEventOnClick
{
    public event Action OnClickEvent = delegate { };

    public void OnClick()
    {
        OnClickEvent();
    }
}
