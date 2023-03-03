using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class FreeCam : MonoBehaviour
{
    Vector2 _mouseAbsolute;
    Vector2 _smoothMouse;

    public Vector2 clampInDegrees = new Vector2(360, 180);
    public Vector2 sensitivity = new Vector2(2, 2);
    public Vector2 smoothing = new Vector2(3, 3);
    public Vector2 targetDirection;
    public Vector2 targetCharacterDirection;

    // Assign this if there's a parent object controlling motion, such as a Character Controller.
    // Yaw rotation will affect this object instead of the camera if set.
    public GameObject characterBody;

    private bool _mouselookEnabled = false;
    private bool _shifted = false;
    public float flySpeed = 0.5f;
    public Camera defaultCamera;


    void Start()
    {
        // Set target direction to the camera's initial orientation.
        targetDirection = transform.localRotation.eulerAngles;

        // Set target direction for the character body to its inital state.
        if (characterBody)
            targetCharacterDirection = characterBody.transform.localRotation.eulerAngles;

    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift) & _shifted)
            _shifted = false;

        if ((Input.GetKeyDown(KeyCode.LeftShift) && !_shifted) |
            (Input.GetKeyDown(KeyCode.Escape) & _mouselookEnabled))
        {
            _shifted = true;

            if (!_mouselookEnabled)
            {
                _mouselookEnabled = true;
                defaultCamera.GetComponent<Camera>().enabled = false;
                this.GetComponent<Camera>().enabled = true;
                GameObject.FindObjectOfType<UIManager>().OnCanvasChange(GameObject.FindObjectsOfType<Canvas>().Where(canvas => canvas.name == "DebugCanvas").ToList()[0]);
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                    _shifted = false;

                _mouselookEnabled = false;
                defaultCamera.GetComponent<Camera>().enabled = true;
                this.GetComponent<Camera>().enabled = false;
                GameObject.FindObjectOfType<UIManager>().OnCanvasChange(GameObject.FindObjectOfType<UIManager>().previousCanvas);
            }
        }

        if (!_mouselookEnabled)
            return;


        // Allow the script to clamp based on a desired target value.
        var targetOrientation = Quaternion.Euler(targetDirection);
        var targetCharacterOrientation = Quaternion.Euler(targetCharacterDirection);

        // Get raw mouse input for a cleaner reading on more sensitive mice.
        var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        // Scale input against the sensitivity setting and multiply that against the smoothing value.
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity.x * smoothing.x, sensitivity.y * smoothing.y));

        // Interpolate mouse movement over time to apply smoothing delta.
        _smoothMouse.x = Mathf.Lerp(_smoothMouse.x, mouseDelta.x, 1f / smoothing.x);
        _smoothMouse.y = Mathf.Lerp(_smoothMouse.y, mouseDelta.y, 1f / smoothing.y);

        // Find the absolute mouse movement value from point zero.
        _mouseAbsolute += _smoothMouse;

        // Clamp and apply the local x value first, so as not to be affected by world transforms.
        if (clampInDegrees.x < 360)
            _mouseAbsolute.x = Mathf.Clamp(_mouseAbsolute.x, -clampInDegrees.x * 0.5f, clampInDegrees.x * 0.5f);

        // Then clamp and apply the global y value.
        if (clampInDegrees.y < 360)
            _mouseAbsolute.y = Mathf.Clamp(_mouseAbsolute.y, -clampInDegrees.y * 0.5f, clampInDegrees.y * 0.5f);

        var xRotation = Quaternion.AngleAxis(-_mouseAbsolute.y, targetOrientation * Vector3.right);
        transform.localRotation = xRotation * targetOrientation;

        // If there's a character body that acts as a parent to the camera
        if (characterBody)
        {
            var yRotation = Quaternion.AngleAxis(_mouseAbsolute.x, characterBody.transform.up);
            characterBody.transform.localRotation = yRotation;
            characterBody.transform.localRotation *= targetCharacterOrientation;
        }
        else
        {
            var yRotation = Quaternion.AngleAxis(_mouseAbsolute.x, transform.InverseTransformDirection(Vector3.up));
            transform.localRotation *= yRotation;
        }

        //movement
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(defaultCamera.transform.forward * flySpeed * Input.GetAxis("Vertical"), Space.World);
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(defaultCamera.transform.right * flySpeed * Input.GetAxis("Horizontal"), Space.World);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.up * flySpeed * 0.5f, Space.World);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(-Vector3.up * flySpeed * 0.5f, Space.World);
        }
    }
}