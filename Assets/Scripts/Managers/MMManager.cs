using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MMManager : MonoBehaviour
{
    PlayerPrefs playerSettings;
    [SerializeField]
    private GameObject contButton;
    [SerializeField]
    private GameObject setBut;

    public Slider vSlider;
    public Slider sSlider;

    private void Awake()
    {
        
    }
    public void NewGame()
    {
        SaveManger.instance.NewGame();
        SceneManager.LoadScene("Lab");
        Time.timeScale = 1.0f;
    }
    public void contGame()
    {
        SaveManger.instance.LoadGame();
    }
    public void SaveSettings()
    {
        
    }
}
