using System;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public int id;
    public void OnClickHandler()
    {
        print("Button" + id);
        GameEvents.instance.ButtonPressed(id);
    }
}