using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnDialogEnd : MonoBehaviour
{
    [SerializeField]
    string name = "";
    IDialogEnd end;
    // Start is called before the first frame update
    void Start()
    {
        end = GetComponent<IDialogEnd>();
        end.OnDialogEnd += HandleDialogEnd;
    }

    private void HandleDialogEnd()
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }


}
