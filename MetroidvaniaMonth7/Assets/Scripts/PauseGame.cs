using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour, IPause
{
    [SerializeField]
    Canvas pauseCanvas;
    bool isPaused = false; 
    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pauseCanvas.enabled = true;
            Time.timeScale = 0;
        }
        else
        {
            pauseCanvas.enabled = false;
            Time.timeScale = 1;
        }

    }
}
