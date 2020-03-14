using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDialogOnCollision : MonoBehaviour, IActiveDialog
{
    [SerializeField]
    bool isActive = false;
    IDialogEnd end;
    IEventOnCollision collision;

    public bool IsActive => isActive;

    public event Action OnDialogStart = delegate { };

    // Start is called before the first frame update
    void Start()
    {
        end = GetComponent<IDialogEnd>();
        end.OnDialogEnd += HandleDialogEnd;
        collision = GetComponent<IEventOnCollision>();
        collision.OnTrigger += HandleCollisionTrigger;
    }

    private void HandleCollisionTrigger()
    {
        if (!isActive)
        {
            isActive = true;
            OnDialogStart();
        }
    }

    private void HandleDialogEnd()
    {
        if (isActive)
        {
            isActive = false;
        }
    }
}
