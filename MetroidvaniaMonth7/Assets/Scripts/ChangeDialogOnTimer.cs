using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDialogOnTimer : MonoBehaviour, IDialogInput
{
    public event Action OnDialogInput = delegate { };
    [SerializeField]
    float delayTime = 3f;
    IActiveDialog active;
    IWriteDialog dialog;
    ITypeCharacter type;
    bool isCharLimitReached = false;

    // Start is called before the first frame update
    void Start()
    {
        active = GetComponent<IActiveDialog>();
        dialog = GetComponent<IWriteDialog>();
        type = GetComponent<ITypeCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active.IsActive)
        {
            if (dialog.DialogLines[type.TypingIndex] == type.TypeContent.text)
            {
                if (!isCharLimitReached)
                {
                    isCharLimitReached = true;
                    StartCoroutine(ChangeDelay());
                }
            }
        }
    }

    IEnumerator ChangeDelay()
    {
        yield return new WaitForSeconds(delayTime);
        isCharLimitReached = false;
        OnDialogInput();
    }
}
