using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public int id;
    public Button intBut;

    private void OnEnable()
    {
        intBut.onClick.AddListener(OnClickHandler);
    }
    private void OnDisable()
    {
        intBut.onClick.RemoveListener(OnClickHandler);
    }
    public void OnClickHandler()
    {
        GameEvents.instance.ButtonPressed(id);
    }
}