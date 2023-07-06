using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpForce = 2.0f;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    private Vector3 direction;
    private Rigidbody rb;
    private Transform cameraTransform;
    private bool jump = false;
    private bool isGrounded;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Take the forward vector of the camera and turn it into a direction for the player
        direction = cameraTransform.forward;
        direction.y = 0;
        direction = direction.normalized;

        Vector3 movement = (direction * moveVertical) + (cameraTransform.right * moveHorizontal);

        rb.AddForce(movement * speed);

        // Use a Physics check to see if we are on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        if(jump)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            jump = false;
        }
    }
}
