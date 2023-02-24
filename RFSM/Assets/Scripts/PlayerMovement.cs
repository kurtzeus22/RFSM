using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float sprintMultiplier = 2f;
    public float dashForce = 10f;
    public float dashCooldown = 2f;
    private float lastDashTime;
    private Rigidbody rb;

    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    public bool isGrounded = false;

    [SerializeField] private Animator animator;

    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if grounded
        isGrounded = Physics.CheckSphere(transform.position, groundCheckRadius, groundLayer);

        // Move the player in all directions
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        

        // Sprint when the left shift is pressed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement *= sprintMultiplier;
        }

        // Dash when the left control is pressed and the dash is off cooldown
        if (Input.GetKeyDown(KeyCode.LeftControl) && Time.time - lastDashTime > dashCooldown)
        {
            rb.AddForce(movement.normalized * dashForce, ForceMode.Impulse);
            lastDashTime = Time.time;
        }
        else
        {
            transform.position += movement * Time.deltaTime * moveSpeed;
        }

        // Make the player jump when the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
        }

        // Update animator
        animator.SetFloat("Speed", movement.magnitude);
        print(movement.magnitude);
        animator.SetBool("IsGrounded", isGrounded);
    }

    private void FixedUpdate()
    {
        // Move player
        /*if (movement != Vector3.zero)
        {
            //float speed = isSprinting ? sprintSpeed : moveSpeed;
            Vector3 targetVelocity = movement * moveSpeed;
            //targetVelocity.y = rb.velocity.y;
            rb.velocity = targetVelocity;

            // Face the dummy to the direction of movement
            transform.rotation = Quaternion.LookRotation(movement);
        }*/
        // Face the dummy to the direction of movement
        transform.rotation = Quaternion.LookRotation(movement);
    }
}

