using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    //Index used to connect Puzzle object to Door
    public int id;
    public enum DoorState
    {
       Close,
       Open
    }
    public DoorState doorState;

    //Subscribes to required events if object exists
    private void OnEnable()
    {
        GameEvents.instance.OnButtonPressed += IToggleDoor;
        GameEvents.instance.OnPlateTrigger += IToggleDoor;
    }
    //Unsubscribes to events if object does not exist
    private void OnDisable()
    {
        GameEvents.instance.OnButtonPressed -= IToggleDoor;
        GameEvents.instance.OnPlateTrigger -= IToggleDoor;
    }

    //Opens door if closed and closes if opened
    public void IToggleDoor(int id)
    {   
        if (this.id == id)
        {
            print(id);
            if (doorState == DoorState.Close)
            {
                this.gameObject.transform.position = Vector3.Lerp(this.transform.position, this.transform.position + new Vector3(0, 3.5f, 0), 1f);
                doorState = DoorState.Open;
            }
            else
            {
                this.gameObject.transform.position = Vector3.Lerp(this.transform.position, this.transform.position + new Vector3(0, -3.5f, 0), 1f);
                doorState = DoorState.Close;
            }
        }
    }
}