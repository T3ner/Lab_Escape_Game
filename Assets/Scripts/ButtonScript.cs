using System;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public int buttonIndex;
    public enum ButtonState{
        On,
        Off
    }
    public ButtonState state;
    public void OnClickHandler()
    {
        if (state == ButtonState.On)
        {
            state = ButtonState.Off;
        }
        else
        {
            state = ButtonState.On;
        }
    }
}