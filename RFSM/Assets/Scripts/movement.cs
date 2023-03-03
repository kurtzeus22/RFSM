using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Animator PlayerAnim;
    private float xInput;// x input
    private float yInput;// y input
    private Vector3 moveDirection;
    private Rigidbody rb;


    public float sprintMultiplier = 2f;
    public float dashForce = 10f;
    public float dashCooldown = 2f;
    private float lastDashTime;

    private float turnSmoothVelocity;

    public float moveSpeed = 2f;
    public float turnSmoothTime = 0.2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        handleMovement();
        handleAnimation();


    }

    void handleMovement()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector3(xInput, 0, yInput).normalized;

        if (moveDirection.magnitude >= 0.1f)
        {
            // for player rotation
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // for player movement
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        }

        // Sprint when the left shift is pressed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveDirection *= sprintMultiplier;
            //moveSpeed *= sprintMultiplier;
        }

        // Dash when the left control is pressed and the dash is off cooldown
        if (Input.GetKeyDown(KeyCode.LeftControl) && Time.time - lastDashTime > dashCooldown)
        {
            rb.AddForce(moveDirection.normalized * dashForce, ForceMode.Impulse);
            
            lastDashTime = Time.time;
        }
        else
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        }
    }
    void handleAnimation()
    {
       

        PlayerAnim.SetFloat("Speed", moveDirection.magnitude);
        //PlayerAnim.SetFloat("mX", xInput);
        // PlayerAnim.SetFloat("mY", yInput);

        //For attack animation
        
    }
}
