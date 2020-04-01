using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveOnSO : MonoBehaviour
{
    [SerializeField]
    GameStateSO state;
    IDialogEnd end;

    // Start is called before the first frame update
    void Start()
    {
        if (state != null && state.isOpeningComplete)
        {
            gameObject.SetActive(false);
        }
        end = GetComponent<IDialogEnd>();
        end.OnDialogEnd += HandleDialogEnd;
    }

    private void HandleDialogEnd()
    {
        state.isOpeningComplete = true;
    }
}
