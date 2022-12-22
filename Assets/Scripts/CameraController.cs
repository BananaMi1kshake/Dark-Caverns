using UnityEngine;

public class CameraController : MonoBehaviour
{
    // The target that the camera will follow
    public Transform target;

    // The distance that the camera should maintain from the target
    public float distance = 10.0f;

    // The height that the camera should maintain above the target
    public float height = 5.0f;

    // The damping factor for the camera's movement
    public float damping = 1.0f;

    // The initial orientation of the camera (used for resetting the camera)
    private Quaternion initialRotation;

    void Start()
    {
        // Save the initial orientation of the camera
        initialRotation = transform.rotation;

        // Set the camera's position to the desired distance and height above the target
        Vector3 position = target.position + Vector3.up * height;
        transform.position = position;
    }

    void LateUpdate()
    {
        // Follow the target with the camera
        Vector3 position = target.position + Vector3.up * height;
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * damping);

        // Keep the camera's rotation fixed (do not look at the target)
        transform.rotation = initialRotation;
    }

    // Reset the camera to its initial orientation
    public void ResetCamera()
    {
        transform.rotation = initialRotation;
    }
}
