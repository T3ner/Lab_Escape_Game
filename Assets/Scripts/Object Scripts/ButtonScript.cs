using System;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Keycard"))
        {
            GameEvents.instance.ButtonPressed(id);  
        }
    }
}