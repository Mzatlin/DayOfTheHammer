using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewLevelOnClick : MonoBehaviour
{
    [SerializeField]
    string name = "";

    public void OnClickNewLevel()
    {

        Time.timeScale = 1;
        FMODUnity.RuntimeManager.PlayOneShot("event:/UIBUtton");
        StartCoroutine(StartDelay());

    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }
}