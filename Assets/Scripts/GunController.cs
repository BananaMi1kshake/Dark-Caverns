using UnityEngine;

public class GunController : MonoBehaviour
{
    // The prefab for the bullet
    public GameObject bulletPrefab;

    // The force with which the bullet is fired
    public float bulletForce = 100.0f;

    // The position from which the bullet is fired
    public Transform bulletSpawnPoint;

    // The camera that the player is looking through
    public Camera playerCamera;

    void Update()
    {
        // Check if the player has pressed the fire button
        if (Input.GetButtonDown("Fire1"))
        {
            // Get the screen point of the mouse cursor
            Vector3 mouseScreenPoint = Input.mousePosition;

            // Convert the screen point to a world point
            Vector3 mouseWorldPoint = playerCamera.ScreenToWorldPoint(new Vector3(mouseScreenPoint.x, mouseScreenPoint.y, playerCamera.transform.position.y));

            // Calculate the direction in which the bullet should be fired
            Vector3 bulletDirection = mouseWorldPoint - bulletSpawnPoint.position;

            // Instantiate a new bullet at the bullet spawn point
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.LookRotation(bulletDirection));

            // Get the Rigidbody component of the bullet
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

            // Add force to the bullet in the direction that the gun is facing
            bulletRigidbody.AddForce(bulletDirection * bulletForce, ForceMode.Impulse);
        }
    }
}
