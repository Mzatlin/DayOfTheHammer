using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDialogOnCollect : MonoBehaviour, IActiveDialog
{
    ICollectable collect;
    [SerializeField]
    bool isActive = false;
    IDialogEnd end;

    public bool IsActive => isActive;

    public event Action OnDialogStart = delegate { };

    // Start is called before the first frame update
    void Start()
    {
        collect = GetComponent<ICollectable>();
        collect.OnCollect += HandleCollect;
        end = GetComponent<IDialogEnd>();
        end.OnDialogEnd += HandleDialogEnd;
    }

    private void HandleCollect()
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
        gameObject.SetActive(false);
    }

}
