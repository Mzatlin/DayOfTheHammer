using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevelOnClick : MonoBehaviour
{
    public void OnReloadClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
