using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.Events;

public class PhotoCamera : MonoBehaviour
{
    [Header("Variables for customising camera raycasts")]
    [SerializeField]
    [Tooltip("This is how far the camera can see")]
    private float maxRange = 10;
    [SerializeField]
    [Tooltip("This is how many rays are shot in each row")]
    private float horizontalSegments = 3;
    [SerializeField]
    [Tooltip("This is how many rays are shot in each column")]
    private float verticalSegments = 3;
    [Header("not important")]
    [SerializeField]
    private Transform playerTransform;

    public Camera playerView;

    private void OnEnable()
    {
        ControlsManager.instance.controls.PhotoModeControls.TakePhoto.performed += context => TakePhoto();
        Debug.Log(ControlsManager.instance.controls.PhotoModeControls.TakePhoto.interactions);
    }

    private void OnDisable()
    {
        ControlsManager.instance.controls.PhotoModeControls.TakePhoto.performed -= context => TakePhoto();
    }

    /// <summary>
    /// This function is called when the player clicks, and it runs all the necessary processes
    /// </summary>
    public void TakePhoto()
    {
        ShootRaycasts();
    }

    /// <summary>
    /// Proportionally divides the camera segments according to the given parameters and shoots raycasts
    /// </summary>
    private void ShootRaycasts()
    {
        Vector3[] frustrumCorners = getCameraCorners();
        Vector3 bottomLeft = playerView.transform.TransformVector(frustrumCorners[0]);
        Vector3 topLeft = playerView.transform.TransformVector(frustrumCorners[1]);
        Vector3 topRight = playerView.transform.TransformVector(frustrumCorners[2]);
        Vector3 bottomRight = playerView.transform.TransformVector(frustrumCorners[3]);

        Vector3 xIncrement = (topRight - topLeft) / horizontalSegments;
        Vector3 yIncrement = (bottomLeft - topLeft) / verticalSegments;

        for(int horizontal = 0; horizontal < horizontalSegments+1; horizontal++)
        {
            for(int vertical = 0; vertical < verticalSegments+1; vertical++)
            {
                Vector3 rayDestination = topLeft + (xIncrement * horizontal) + (yIncrement * vertical);
                rayDestination = Vector3.Normalize(rayDestination) * maxRange;
                RaycastHit cameraRay;
                if(Physics.Raycast(playerTransform.position, rayDestination, out cameraRay, maxRange))
                {
                    if (cameraRay.transform.gameObject.GetComponent<PhotographableObject>() != null)
                    {
                        PhotographableObject hintObject = cameraRay.transform.gameObject.GetComponent<PhotographableObject>();
                        hintObject.AddHintToJournal();
                    }
                }
                //Debug.DrawRay(playerView.transform.position, rayDestination, Color.blue, 10);
            }
        }
        //TODO for loop which starts in the top left and loops along until it covers the camera in the x and y direction
    }


    /// <summary>
    /// Generates a Vector3 array which returns the transforms of the camera frustrums
    /// </summary>
    /// <returns>Returns an array of vectors, containing the camera frustrums</returns>
    private Vector3[] getCameraCorners()
    {
        Vector3[] corners = new Vector3[4];
        playerView.CalculateFrustumCorners(new Rect(0, 0, 1, 1), playerView.farClipPlane, Camera.MonoOrStereoscopicEye.Mono, corners);
        /*
        for (int i = 0; i < 4; i++)
        {
            // 0 = bottom left
            // 1 = top left
            // 2 = top right
            // 3 = bottom right
             * Debug rays to check frustrums:
            Debug.DrawRay(playerView.transform.position, playerView.transform.TransformVector(corners[0]), Color.blue, 10);
            Debug.DrawRay(playerView.transform.position, playerView.transform.TransformVector(corners[1]), Color.red, 10);
            Debug.DrawRay(playerView.transform.position, playerView.transform.TransformVector(corners[2]), Color.green, 10);
            Debug.DrawRay(playerView.transform.position, playerView.transform.TransformVector(corners[3]), Color.yellow, 10);
        }
        */
        

        return corners;
    }
}
