using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCanvasOnInteract : MonoBehaviour
{
    [SerializeField]
    Canvas activateCanvas;
    [SerializeField]
    float delayTime = 3f;
    IInteractable interact;
    bool isActivated = false;


    // Start is called before the first frame update
    void Start()
    {
        if(activateCanvas != null)
        {
            activateCanvas.enabled = false;
        }
        else
        {
            Debug.Log("No canvas assigned to GameObject!");
        }

        interact = GetComponent<IInteractable>();
        if(interact != null)
        {
            interact.OnInteract += HandleInteract;
        }
    }

    private void HandleInteract()
    {
        if (!isActivated)
        {
            isActivated = true;
            StartCoroutine(ActiveDelay());
        }
    }

    IEnumerator ActiveDelay()
    {
        activateCanvas.enabled = true;
        yield return new WaitForSeconds(delayTime);
        isActivated = false;
        activateCanvas.enabled = false;
    }



}
