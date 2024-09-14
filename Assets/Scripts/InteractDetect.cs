using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InteractDetect : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    float sphereRad;
    
    Vector3 collDist1;
    Vector3 collDist2;
    public Collider[] interactables;

    public GameObject interactButton;

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
            interactButton.SetActive(true);
           
            //Changes button text base on which Interactable object is closest
            TextMeshProUGUI buttonText = interactButton.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.SetText(interactables[0].name);
        }
        else
        {
            interactButton.SetActive(false);
        }
    }
}
