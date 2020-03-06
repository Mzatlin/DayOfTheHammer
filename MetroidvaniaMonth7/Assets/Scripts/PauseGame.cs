using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour, IPause
{
    [SerializeField]
    Canvas pauseCanvas;
    Button button;
    PauseOnClick click;
    bool isPaused = false; 
    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas.enabled = false;
        button = pauseCanvas.GetComponentInChildren<Button>();
        click = pauseCanvas.GetComponentInChildren<PauseOnClick>();
        click.OnResume += HandleResume;
        button.interactable = false;

    }

    private void HandleResume()
    {
        TogglePause();
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
            button.interactable = true;
            pauseCanvas.enabled = true;
            Time.timeScale = 0; //reminder that when the player leaves to the main menu, this is still frozen
        }
        else
        {
            button.interactable = false; ;
            pauseCanvas.enabled = false;
            Time.timeScale = 1;
        }

    }
}
