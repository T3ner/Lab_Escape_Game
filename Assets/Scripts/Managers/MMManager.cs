using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MMManager : MonoBehaviour
{
    [SerializeField]
    private GameObject contButton;
    [SerializeField]
    private GameObject setBut;

    [SerializeField]

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
    public void settings()
    {

    }
}
