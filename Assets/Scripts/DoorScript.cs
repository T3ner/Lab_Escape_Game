using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    //Index used to connect Button to Door
    public int doorIndex;
    public ButtonScript Button;

    //Opens door if closed and closes if opened
    public void MoveDoor()
    {
        if (doorIndex == Button.buttonIndex)
        {
            if (Button.state == ButtonScript.ButtonState.On)
            {
                this.gameObject.transform.position = Vector3.Lerp(this.transform.position, this.transform.position + new Vector3(0, 5.0f, 0), 1.0f);
            }
            else
            {
                this.gameObject.transform.position = Vector3.Lerp(this.transform.position, this.transform.position + new Vector3(0, -5.0f, 0), 1.0f);
            }
        }

    }
}
