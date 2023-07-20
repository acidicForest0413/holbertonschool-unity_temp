using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Assuming that your PauseMenu Canvas is attached to this same GameObject
    public GameObject pauseCanvas;
    
    // This boolean keeps track of whether or not the game is currently paused
    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        // Check if the Esc key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Resume function
    public void Resume()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f; // This will make the game run at normal speed
        isPaused = false;
    }

    // Pause function
    public void Pause()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f; // This will stop time in the game, effectively pausing it
        isPaused = true;
    }
}
