using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 velocity;
    private Vector3 playerMovementInput;
    private Vector2 playerMouseInput;
    private float xRotation;

    public Transform playerCamera;
    public CharacterController controller;
    public Transform player;

    public bool isPaused;
    public float speed;
    public float jump;
    public float sensitivity;
    public float gravity = 9.81f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused == false)
        {
            playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            playerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            movePlayer();
            moveCamera();
        }
    }

    public void pauseGame(bool p)
    {
        isPaused = p;
    }

    private void movePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(playerMovementInput);

        if (controller.isGrounded == true)
        {
            velocity.y = -1;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = jump;
            }
        }
        else
        {
            velocity.y += gravity * -2 * Time.deltaTime;
        }
        controller.Move(moveVector * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }

    private void moveCamera()
    {
        xRotation -= playerMouseInput.y * sensitivity;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.Rotate(0, playerMouseInput.x * sensitivity, 0);
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}