using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // The player's movement speed
    public float turnSpeed = 10.0f; // The player's turn speed

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = 0;
        float moveVertical = Input.GetAxis("Vertical");
        float horizontalMouse = Input.GetAxis("Mouse X");
        transform.Rotate(0, horizontalMouse * turnSpeed, 0);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 movementDirection = moveHorizontal * Camera.main.transform.right + moveVertical * cameraForward;
        GetComponent<Rigidbody>().velocity = movementDirection * moveSpeed;
        movement = Quaternion.Euler(0, transform.eulerAngles.y, 0) * movement;

        rb.AddForce(movement * moveSpeed);
    }
}