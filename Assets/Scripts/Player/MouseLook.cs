using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 30f;
    public Transform playerBody;
    float xRotation = 0f;
    public bool activeCamera = true;

    private Camera cam;
    public static MouseLook instance;
    private Vector2 mousePos = Vector2.zero;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        
    }
	//private void OnEnable()
	//{
 //       ControlsManager.instance.controls.Look.Look.performed += context => mousePos = context.action.ReadValue<Vector2>();
 //   }
	//private void OnDisable()
	//{
 //       ControlsManager.instance.controls.Look.Look.performed -= context => mousePos = context.action.ReadValue<Vector2>();
 //   }

	// Start is called before the first frame update
	void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//loacks cursor to screen
        Cursor.visible = false; //makes cursor invisible
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activeCamera)
        {
            float sensitivity = mouseSensitivity;
            float mouseX = mousePos.x * sensitivity * Time.deltaTime; //takes in the user mouse movement on the X axis and times by the mouse sensitivity
            float mouseY = mousePos.y * sensitivity * Time.deltaTime; //takes in the user mouse movement on the Y axis and times by the mouse sensitivity

            xRotation -= mouseY; // invert the output to make it more natural
            xRotation = Mathf.Clamp(xRotation, -85f, 85f); //clamp it to stop you from spinning camera 360

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //rotates the camera up and down on the local X axis
            playerBody.Rotate(Vector3.up * mouseX);// rotates the player body on the cameras Y rotation
        }
    }

    public void OnLook(CallbackContext context)
    {
        mousePos = context.action.ReadValue<Vector2>();
    }
}