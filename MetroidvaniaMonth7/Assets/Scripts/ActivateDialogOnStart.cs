using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDialogOnStart : MonoBehaviour, IActiveDialog
{
    public event Action OnDialogStart = delegate { };

    [SerializeField]
    bool isActive = false;
    [SerializeField]
    float startDelay = 1f;
    IDialogEnd end;

    public bool IsActive => isActive;




    // Start is called before the first frame update
    void Start()
    {
        end = GetComponent<IDialogEnd>();
        end.OnDialogEnd += HandleDialogEnd;
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(startDelay);
        OnDialogStart();
        isActive = true;
    }

 void HandleDialogEnd()
{
    if (isActive)
    {
        isActive = false;
    }
}

}
