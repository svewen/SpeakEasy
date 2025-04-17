using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    Vector3 velocity;

    public float speed = 2f;
    public float sprintSpeed = 5f;
    public float walkSpeed = 2f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public float jumpHeight = 2f;
    public LayerMask groundMask;
    private bool isGrounded;

    private void Update()
    {
        // Check if player is on ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Handle Sprinting
        if (Input.GetKey(KeyCode.LeftShift))
            speed = sprintSpeed;
        else
            speed = walkSpeed;

        // Move based on WASD, etc
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E Key Pressed");
            //Interact();
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    //private void Interact()
    //{
    //    RaycastHit hit;

    //    // Cast a ray from this object forward
    //    if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
    //    {
    //        if (hit.collider.CompareTag("NPC"))
    //        {
    //            Debug.Log("hit npc");
    //        }
    //    }
    //    else
    //    {
    //        Debug.Log("Nothing detected in front.");
    //    }

    //    // show ray in scene view
    //    Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red, 1f);
    //}
}
