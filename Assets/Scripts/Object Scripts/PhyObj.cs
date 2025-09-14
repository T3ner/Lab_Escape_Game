using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhyObj : MonoBehaviour
{
    public bool picked;

    private void Awake()
    {
        picked = false;
    }

    private void Update()
    {
        if (this.GetComponentInParent<GameObject>() != null)
        {
            picked = false;
        }
        else
        {
            picked = true;
        }
    }
}
