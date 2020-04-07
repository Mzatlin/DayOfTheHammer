using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewLevelOnClick : OnClickListenerBase
{
    [SerializeField]
    string levelName = "";

    public override void HandleClickEvent()
    {
        Time.timeScale = 1;
        FMODUnity.RuntimeManager.PlayOneShot("event:/UIBUtton");
        StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }
}