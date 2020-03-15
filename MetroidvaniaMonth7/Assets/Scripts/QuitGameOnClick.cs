using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameOnClick : MonoBehaviour
{
    public void OnClickQuit()
    {
        Application.Quit();
        FMODUnity.RuntimeManager.PlayOneShot("event:/UIBUtton");

    }
}
