using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitchController : MonoBehaviour
{
    [SerializeField]
    List<GameObject> switches = new List<GameObject>();
    bool isComplete = false;
    bool switchSound = false;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject obj in switches)
        {
            obj.GetComponent<SwitchController>().isTriggered = false;
            obj.GetComponent<SwitchController>().OnTrigger += HandleTrigger;
        }
    }

    private void HandleTrigger()
    {
        foreach(GameObject obj in switches)
        {
           if(obj.GetComponent<SwitchController>().isTriggered == false)
            {
                isComplete = false;
                gameObject.SetActive(true);
                FMODUnity.RuntimeManager.PlayOneShot("event:/Objects/DoorUnlocked", GetComponent<Transform>().position);
                return;
            }
        }
        isComplete = true;
        gameObject.SetActive(false);
        if (isComplete != switchSound)
        {
            switchSound = isComplete;
            FMODUnity.RuntimeManager.PlayOneShot("event:/Objects/DoorUnlocked", GetComponent<Transform>().position);
        }
    }

}
