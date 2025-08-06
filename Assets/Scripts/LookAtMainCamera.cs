using UnityEngine;

public class LookAtMainCamera : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        // Find the main camera at the start. This is more efficient than searching every frame.
        mainCamera = Camera.main;

        // Check if a main camera exists. If not, log a warning.
        if (mainCamera == null)
        {
            Debug.LogWarning("No Main Camera found in the scene. Please tag a camera as MainCamera.");
            // You might want to disable this script or handle the error differently.
            enabled = false; // Disable the script if no camera is found
            return;
        }
    }

    void Update()
    {
        // Only proceed if a camera was found
        if (mainCamera != null)
        {
            // Method 1: Using LookAt (Simplest, but can cause unwanted rotation on other axes)
            transform.LookAt(mainCamera.transform);

            // Method 2: Calculating the rotation (More control over up direction)
            //Vector3 targetPosition = mainCamera.transform.position;

            //// Optional: Adjust the target position's y-coordinate to prevent the object from tilting up/down.
            ////targetPosition.y = transform.position.y; // Keep the object's original y position

            //// Calculate the direction vector from the object to the camera.
            //Vector3 lookDirection = targetPosition - transform.position;

            //// Create a rotation based on the look direction.
            //Quaternion targetRotation = Quaternion.LookRotation(lookDirection);

            //// Apply the rotation to the object.
            //transform.rotation = targetRotation;

            //Method 3: Smooth Rotation
          //  float smoothSpeed = 5f;
           // Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
           // transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);

        }
    }
}