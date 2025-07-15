using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class lvlTrigger : MonoBehaviour
{
    public GameObject Loadlvl;
    public GameObject Currentlvl;
    public Vector3 lvlStart;
    public GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.position = lvlStart;
            GameEvents.instance.LevelTransition(lvlStart);
            Loadlvl.SetActive(true);
            Currentlvl.SetActive(false);
        }
    }
}
