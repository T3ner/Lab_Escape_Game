using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InteractDetect : MonoBehaviour
{
    enum PickState
    {
        Picked,
        Empty
    }
    public Transform player;
    public float sphereRad;
    public GameObject handSlot;
    
    Vector3 collDist1;
    Vector3 collDist2;
    string intActName;

    public Collider[] interactables;
    public GameObject interactButObj;
    public GameObject pickUpButObj;
    public GameObject dropButObj;

    PickState pickState;

    private void Start()
    {
        pickState = PickState.Empty;
    }

    private void Update()
    {
        interactables = Physics.OverlapSphere(player.position, sphereRad, layerMask: 1 << 6);
        if (interactables.Length != 0)
        {
            //Sorting algorithm to set 1st element of interactables array to the closest interactable object
            if(interactables.Length > 1)
            {
                for (int i = 0; i < interactables.Length - 1; i++)
                {
                    collDist1 = interactables[i].transform.position - player.transform.position;
                    collDist2 = interactables[i + 1].transform.position - player.transform.position;

                    if (collDist2.sqrMagnitude > collDist1.sqrMagnitude)
                    {
                        Collider temp = interactables[i];
                        interactables[i] = interactables[i + 1];
                        interactables[i + 1] = temp;
                    }
                }
            }
           
            //Changes button text based on which Interactable object is closest
            if (interactables[0].name.Contains("Button"))
            {
                if (interactButObj.activeSelf || dropButObj.activeSelf)
                {
                    pickUpButObj.SetActive(false);
                }

                interactButObj.SetActive(true);
                intActName = "Toggle";
                interactButObj.GetComponentInChildren<TextMeshProUGUI>().SetText(intActName);

            }
            else if (interactables[0].name.Contains("Pick") && pickState == PickState.Empty)
            {
                if (pickUpButObj.activeSelf || dropButObj.activeSelf)
                {
                    interactButObj.SetActive(false);
                }

                pickUpButObj.SetActive(true);
                intActName = "Pick Up";
                pickUpButObj.GetComponentInChildren<TextMeshProUGUI>().SetText(intActName);
            }
        }
        //Disables UI buttons
        else
        {
            pickUpButObj.SetActive(false);
            interactButObj.SetActive(false);
        }

        //Drop Button toggle
        if (handSlot.GetComponentInChildren<Rigidbody>() != null && pickState == PickState.Picked)
        {
            if (interactButObj.activeSelf || pickUpButObj.activeSelf)
            {
                dropButObj.SetActive(false);
            }

            dropButObj.SetActive(true);
            intActName = "Drop";
            dropButObj.GetComponentInChildren<TextMeshProUGUI>().SetText(intActName);
        }
        else
        {
            dropButObj.SetActive(false);
        }
    }

    public void PickUp()
    {
        if (interactables.Length == 0) return; // Safety check if no interactable object is present

        // Get the Rigidbody of the closest object
        Rigidbody pickable = interactables[0].GetComponent<Rigidbody>();

        // Make it kinematic (disable physics)
        pickable.isKinematic = true;

        // Parent it to the hand slot
        pickable.transform.SetParent(handSlot.transform);

        // Reposition it to the hand slot
        pickable.transform.localPosition = Vector3.zero; // Reset position relative to handSlot
        pickable.transform.localRotation = Quaternion.identity; // Reset rotation relative to handSlot

        pickState = PickState.Picked;
    }

    public void Drop()
    {
        Rigidbody handHeld = handSlot.GetComponentInChildren<Rigidbody>();
        handHeld.isKinematic = false;

        handHeld.transform.SetParent(null);

        pickState = PickState.Empty;
    }
}