using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public event Action<int> OnButtonPressed;
    public void ButtonPressed(int id)
    {
        OnButtonPressed?.Invoke(id);
    }

    public event Action<int> OnPlateTrigger;
    public void PlateTrigger(int id) 
    {
        OnPlateTrigger?.Invoke(id); 
    }
}
