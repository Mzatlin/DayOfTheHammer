using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SwitchController : MonoBehaviour, ISwitch
{
    IMoveBlock move;
    public event Action OnTrigger = delegate { };
    public bool isTriggered = false;
    Animator animate;

    void Start()
    {
        animate = GetComponentInChildren<Animator>();
    }


    void OnTriggerStay2D(Collider2D collision)
    {
        move = collision.GetComponent<IMoveBlock>();
        if(move != null && !isTriggered)
        {
            animate.SetBool("IsSwitched", true);
            isTriggered = true;
            OnTrigger();

        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        move = collision.GetComponent<IMoveBlock>();
        if (move != null && isTriggered)
        {
            animate.SetBool("IsSwitched", false);
            isTriggered = false;
            OnTrigger();
        }
    }
}
