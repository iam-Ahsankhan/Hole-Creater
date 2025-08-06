using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public float mouseSensitivity = 2f;
    public float movementSpeed = 5f;
    public float gravity = 9.81f;
    public float jumpHeight = 2f;

    private float xRotation = 0f;
    private float yRotation = 0f;
    private CharacterController characterController;
    private Vector3 velocity;

    void Start()
    {
       
       
        // Get the CharacterController component.
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            Debug.LogError("FPSCamera script requires a CharacterController component on the same GameObject.");
            enabled = false;
            return;
        }
    }

    void Update()
    {
        // Mouse Look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Prevents looking too far up/down

        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

        // Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        moveDirection.Normalize(); // Prevents faster diagonal movement
        moveDirection *= movementSpeed;

        // Apply gravity
        if (characterController.isGrounded)
        {
            velocity.y = 0f; // Reset vertical velocity when grounded
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(2f * jumpHeight * gravity);
            }
        }

        velocity.y -= gravity * Time.deltaTime; // Apply gravity

        moveDirection += velocity;

        characterController.Move(moveDirection * Time.deltaTime);

        // Escape to unlock cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}