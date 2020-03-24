using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnDialogInput : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string inputPath;
    IActiveDialog input;

    void Start()
    {
        input = GetComponent<IActiveDialog>();
        input.OnDialogStart += HandleStart;
    }

    private void HandleStart()
    {
        FMODUnity.RuntimeManager.PlayOneShot(inputPath, transform.position);
    }
}
