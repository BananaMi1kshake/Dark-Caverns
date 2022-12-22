using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // The speed at which the player moves
    public float moveSpeed = 5.0f;

    // The layer mask for the ground
    public LayerMask groundLayer;

    // The rigidbody component of the player
    private Rigidbody rb;

    // The camera that the player is looking through
    public Camera playerCamera;

    void Start()
    {
        // Get the rigidbody component of the player
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement vector
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

        // Normalize the movement vector and scale it by the move speed
        movement = movement.normalized * moveSpeed * Time.deltaTime;

        // Move the player
        rb.MovePosition(transform.position + movement);

        // Rotate the player towards the mouse cursor
        RotateTowardsMouse();
    }

    // Rotate the player towards the mouse cursor
    private void RotateTowardsMouse()
    {
        // Get the screen point of the mouse cursor
        Vector3 mouseScreenPoint = Input.mousePosition;

        // Convert the screen point to a world point
        Vector3 mouseWorldPoint = playerCamera.ScreenToWorldPoint(new Vector3(mouseScreenPoint.x, mouseScreenPoint.y, playerCamera.transform.position.y));

        // Calculate the rotation needed to look at the mouse world point
        Quaternion rotation = Quaternion.LookRotation(mouseWorldPoint - transform.position, Vector3.up);

        // Apply the rotation, but only on the y axis
        transform.rotation = Quaternion.Euler(0, rotation.eulerAngles.y, 0);
    }
}
