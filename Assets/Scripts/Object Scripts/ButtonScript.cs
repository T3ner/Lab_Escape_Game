using System;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public int id;
    public void OnClickHandler()
    {
        GameEvents.instance.ButtonPressed(id);
    }
}