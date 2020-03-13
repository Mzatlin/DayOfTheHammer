using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SwitchController : MonoBehaviour, ISwitch
{
    IMoveBlock move;
    public event Action OnTrigger = delegate { };
    public bool isTriggered;
    Animator animate;

    void Start()
    {
        animate = GetComponentInChildren<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        move = collision.GetComponent<IMoveBlock>();
        if(move != null)
        {
            animate.SetBool("IsSwitched", true);
            isTriggered = true;
            OnTrigger();

        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        move = collision.GetComponent<IMoveBlock>();
        if (move != null)
        {
         //   animate.SetBool("IsSwitched", false);
            isTriggered = false;
            OnTrigger();
        }
    }
}
