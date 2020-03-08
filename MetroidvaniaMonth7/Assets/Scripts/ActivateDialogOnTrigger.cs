using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActivateDialogOnTrigger : MonoBehaviour, IActiveDialog
{
    public event Action OnDialogStart = delegate { };

    [SerializeField]
    PlayerStateSO playerState;
    IInteractable interact;
    IDialogEnd end;
    [SerializeField]
    bool isActive = false;

    public bool IsActive => isActive;

    // Start is called before the first frame update
    void Start()
    {
        interact = GetComponent<IInteractable>();
        interact.OnInteract += HandleInteraction;
        end = GetComponent<IDialogEnd>();
        end.OnDialogEnd += HandleDialogEnd;
    }

    private void HandleDialogEnd()
    {
        if (isActive)
        {
            isActive = false;
        }
    }

    private void HandleInteraction()
    {
        if (!isActive)
        {
            isActive = true;
            OnDialogStart();
        }
    }

}
