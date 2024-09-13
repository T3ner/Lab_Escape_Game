using Unity.Mathematics;
using UnityEngine;
using Screen = UnityEngine.Device.Screen;

public class Look : MonoBehaviour
{
    Vector3 startPos;
    Vector3 dir;
    GameObject player;
    [SerializeField] float damper;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
           
        }
    }

}
