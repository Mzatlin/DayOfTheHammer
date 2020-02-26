using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitchController : MonoBehaviour
{
    [SerializeField]
    List<GameObject> switches = new List<GameObject>();
    bool isComplete = false;
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
                return;
            }
        }
        isComplete = true;
        gameObject.SetActive(false);
    }

}
