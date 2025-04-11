using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorScript : MonoBehaviour
{
    public GameObject doorLeft;
    public GameObject doorRight;
    public Transform dfTransform;
    public Transform drTransform;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OpenDoor;
    }
    private void Start()
    {
        dfTransform = doorLeft.transform;
        drTransform = doorRight.transform;

        dfTransform.Translate(-1f, 0, 0);
        drTransform.Translate(1f, 0, 0);
    }

    void OpenDoor(Scene scene, LoadSceneMode mode)
    {
        scene = SceneManager.GetActiveScene();
        mode = LoadSceneMode.Additive;

    }
}
