using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnDialogEnd : MonoBehaviour
{
    IDialogEnd end;
    // Start is called before the first frame update
    void Start()
    {
        end = GetComponent<IDialogEnd>();
        end.OnDialogEnd += HandleDialogEnd;
    }

    private void HandleDialogEnd()
    {
        gameObject.SetActive(false);
    }
}
