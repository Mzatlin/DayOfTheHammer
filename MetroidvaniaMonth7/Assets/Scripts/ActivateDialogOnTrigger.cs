using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDialogOnTrigger : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;
    [SerializeField]
    PlayerStateSO playerState;
    IInteractable interact;
    bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        interact = GetComponent<IInteractable>();
        interact.OnInteract += HandleInteraction;
        canvas.enabled = false;
    }

    private void HandleInteraction()
    {
        canvas.enabled = true;
        isActive = true;
        playerState.isStopped = true;
    }

    private void Update()
    {
        if(isActive && Input.GetKeyDown(KeyCode.Space))
        {
            canvas.enabled = false;
            playerState.isStopped = false;

        }

    }

}
