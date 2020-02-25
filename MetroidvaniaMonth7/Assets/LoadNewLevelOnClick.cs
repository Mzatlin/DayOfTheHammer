using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewLevelOnClick : MonoBehaviour
{
    [SerializeField]
    string name;

    public void OnClickNewLevel()
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }
}
