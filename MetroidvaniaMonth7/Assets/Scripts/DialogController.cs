using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogController : WriterBase, ITypeCharacter, IDialogEnd
{
    public event Action OnDialogEnd = delegate { };

    [SerializeField]
    float typingSpeed = 1f;
    [SerializeField]
    Canvas dialogCanvas;
    [SerializeField]
    TextMeshProUGUI textContent;
    IActiveDialog dialogActivate;
    IDialogInput input;
    int index = 0;

    public float TypingSpeed => typingSpeed;
    public int TypingIndex { get => index; set => index = value; }
    public TextMeshProUGUI TypeContent => textContent;

    // Start is called before the first frame update
    void Awake()
    {
        dialogCanvas.enabled = false;
        dialogActivate = GetComponent<IActiveDialog>();
        dialogActivate.OnDialogStart += HandleDialogStart;
        input = GetComponent<IDialogInput>();
        input.OnDialogInput += HandleInput;
        textContent.text = "";
    }

    private void HandleInput()
    {
        if(index >= dialogLines.Count - 1)
        {
            CloseDialog();
        }
        else
        {
            index++;
            textContent.text = "";
            WriteDialog(dialogLines[index]);
        }

    }

    void CloseDialog()
    {
        OnDialogEnd();
        dialogCanvas.enabled = false;
        textContent.text = "";
        index = 0;
    }

    private void HandleDialogStart()
    {
        dialogCanvas.enabled = true;
        WriteDialog(dialogLines[index]);
    }

    public override void WriteDialog(string textLine)
    {
        StopCoroutine(TypeMessage(textLine));
        StartCoroutine(TypeMessage(textLine));
    }

    IEnumerator TypeMessage(string message)
    {
        foreach(char i in message.ToCharArray())
        {
            textContent.text += i;
            yield return new WaitForSeconds(typingSpeed);

            //Move this to its own script 
            FMODUnity.RuntimeManager.PlayOneShot("event:/Typing", GetComponent<Transform>().position);

        }
    }
}
