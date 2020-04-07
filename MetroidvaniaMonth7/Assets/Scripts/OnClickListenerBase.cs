using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OnClickListenerBase : MonoBehaviour
{
    protected IEventOnClick click;
    // Start is called before the first frame update
    void Awake()
    {
        click = GetComponent<IEventOnClick>();
        if(click != null)
        {
            click.OnClickEvent += HandleClickEvent;
        }
    }

    public abstract void HandleClickEvent();
}
