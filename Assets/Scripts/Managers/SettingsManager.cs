using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject setMenu;

    [SerializeField]
    private GameObject senSlider;
    
    public void Back()
    {
        setMenu.SetActive(false);
    }
    
    public void Save()
    {

    }
}
