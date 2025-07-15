using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager :MonoBehaviour
{
    [SerializeField] 
    private GameObject pauseMenu;
    [SerializeField] 
    private GameObject pauseButton;

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
        SceneManager.LoadScene("MainMenu");
    }
}
