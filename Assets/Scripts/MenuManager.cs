using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager :MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public void Pause()
    {
        Time.timeScale = 0.0f;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
