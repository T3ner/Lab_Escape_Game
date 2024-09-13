
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayMech : MonoBehaviour
{
    PlayerInput playerInput;
    public bool grounded;
    [SerializeField] CharacterController playerChar;
    [SerializeField] float rotationSensitivity;
    [SerializeField] GameObject playerObj;
    Camera playerCam;

    Vector3 velocity;
    float gravVel;
    float speed = 15f;
    float camPitch;
    float camYaw;
    
    void Awake()
    {
        if (playerCam == null)
        {
            playerCam = GetComponentInChildren<Camera>();
        }
        //Initailize Imp values
        gravVel = -9.8f;

        //Getting refrences to imp player components
        playerInput = GetComponent<PlayerInput>();
        playerChar = GetComponent<CharacterController>();
    }

    void Update()
    {
        grounded = playerChar.isGrounded;

        Vector2 moveInput;
        moveInput = playerInput.actions["Move"].ReadValue<Vector2>();

        //Joystick Movement
        Vector3 movement = new Vector3(moveInput.x, velocity.y, moveInput.y);
        playerObj.transform.Translate(movement * Time.deltaTime *speed);

        CameraRotation();

        if (!grounded)
        {
            velocity.y += gravVel * Time.deltaTime;
        }
    }

    public void CameraRotation()
    {
        Vector2 lookInput = playerInput.actions["Look"].ReadValue<Vector2>();
        camPitch += lookInput.y * rotationSensitivity * Time.deltaTime;
        camYaw = lookInput.x * rotationSensitivity * Time.deltaTime;

        camPitch = Mathf.Clamp(camPitch, -45f, 45f);
        playerCam.transform.localRotation = Quaternion.Euler(camPitch, 0, 0);
        playerObj.transform.Rotate(Vector3.up * camYaw);
    }
}