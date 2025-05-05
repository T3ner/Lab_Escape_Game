using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PhyObj")
        {
            GameEvents.instance.PlateTrigger(id);
        }
    } 
}
