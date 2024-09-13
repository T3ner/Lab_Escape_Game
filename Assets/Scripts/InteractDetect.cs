using UnityEngine;

public class InteractDetect : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    Collider[] interactables;
    [SerializeField]
    float sphereRad;
    
    Vector3 collDist1;
    Vector3 collDist2;

    private void Update()
    {
       interactables =  Physics.OverlapSphere(player.position, sphereRad, layerMask: 1 << 6);

        if (interactables != null)
        {
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
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(player.position, sphereRad);
    }
}
