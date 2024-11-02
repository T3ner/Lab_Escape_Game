using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class InteractDetect : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    float sphereRad;
    [SerializeField]
    GameObject handSlot;
    
    Vector3 collDist1;
    Vector3 collDist2;
    string intActName;

    public Collider[] interactables;
    public GameObject interactButton;
    public GameObject pickUpButton;

    public UnityEvent interactEvent;

    private void Update()
    {
       interactables =  Physics.OverlapSphere(player.position, sphereRad, layerMask: 1 << 6);

        if (interactables.Length != 0)
        {
            //Sorting algorithm to set 1st element of interactables array to the closest interactable object
            for (int i = 0; i < interactables.Length - 1; i++)
            {
                collDist1 = interactables[i].transform.position - player.transform.position;
                collDist2 = interactables[i+1].transform.position - player.transform.position;

                if (collDist2.sqrMagnitude > collDist1.sqrMagnitude)
                {
                    Collider temp = interactables[i];
                    interactables[i] = interactables[i+1];
                    interactables[i+1] = temp;
                }
            }
           
            //Changes button text based on which Interactable object is closest
            if (interactables[0].name.Contains("Button"))
            {
                interactButton.SetActive(true);
                intActName = "Open";
                interactButton.GetComponentInChildren<TextMeshProUGUI>().SetText(intActName);
            }else if (interactables[0].name.Contains("Pick"))
            {
                pickUpButton.SetActive(true);
                intActName = "Pick Up";
                pickUpButton.GetComponentInChildren<TextMeshProUGUI>().SetText(intActName);
            }
            else
            {
                return;
            }
        }
        else
        {
            pickUpButton.SetActive(false);
            interactButton.SetActive(false);
        }
    }

    public void PickUp()
    {
        Rigidbody pickable = interactables[0].GetComponent<Rigidbody>();

        if (interactables[0].CompareTag("PhyObj"))
        {
            pickable.transform.position = handSlot.transform.position;
        }
    }

}
