using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Speed variable to control movement speed
    public float speed = 5.0f;

    // Rotation speed for turning the vehicle
    public float rotationSpeed = 100.0f;

    // Reference to the camera
    public Camera mainCamera;

    // Offset between the camera and the vehicle
    private Vector3 cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the camera offset (distance between camera and vehicle)
        if (mainCamera != null)
        {
            cameraOffset = mainCamera.transform.position - transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Manual vehicle movement with arrow keys or WASD
        float moveVertical = Input.GetAxis("Vertical"); // Forward/Backward input
        float moveHorizontal = Input.GetAxis("Horizontal"); // Left/Right input

        // Move the vehicle forward/backward
        transform.Translate(Vector3.forward * moveVertical * speed * Time.deltaTime);

        // Rotate the vehicle left/right
        transform.Rotate(Vector3.up, moveHorizontal * rotationSpeed * Time.deltaTime);

        // Camera follows the vehicle
        if (mainCamera != null)
        {
            mainCamera.transform.position = transform.position + cameraOffset;
            mainCamera.transform.LookAt(transform.position); // Camera always looks at the vehicle
        }
    }
}
ss