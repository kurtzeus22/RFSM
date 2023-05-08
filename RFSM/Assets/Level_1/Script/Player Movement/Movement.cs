using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
//using UnityEngine.InputSystem;



public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public GameObject PlayerModel;

    public static float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    Vector3 velocity;
    bool isGrounded;
    bool jumping;
    public static bool isAiming;
    

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    public KeyCode skill4 = KeyCode.Alpha4;
    private bool m_isAxisInUse = false;

    void Start(){

    }
    // Update is called once per frame
    void Update()
    {
        if(isAiming == false){
            Cursor.lockState = CursorLockMode.Locked;
        }
        if(isAiming == true){
            Cursor.lockState = CursorLockMode.Locked;
        }
        //jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown("space") && isGrounded || Input.GetButtonDown("GPJump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        if (Input.GetKeyUp(KeyCode.Alpha1) && isGrounded || Input.GetButtonUp("GPSkill1") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }


        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        //walk
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if(isAiming == false){
            if(direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);    
            }
        }

        //Animation Play
        if(Input.GetKeyDown("space") || Input.GetButtonDown("GPJump")){
            jumping = true;
            PlayerModel.GetComponent<Animator>().Play("jumpAnim");
            StartCoroutine(AfterJump());
        }
        IEnumerator AfterJump(){
            yield return new WaitForSeconds(0.8f);
            jumping = false;
            // PlayerModel.GetComponent<Animator>().Play("idleAnim");
        }

        if(BasicAttack1.hasGun == false){
            if(BasicAttack1.basicAttack == false){
                if (Health.isHit == false)
                {
                    if (Input.GetKey("w") && jumping == true || Input.GetKey("a") && jumping == true || Input.GetKey("s") && jumping == true || Input.GetKey("d") && jumping == true){
                        PlayerModel.GetComponent<Animator>().Play("jumpAnim");
                    }
                    if(Input.GetAxisRaw("Horizontal") != 0 && jumping == true || Input.GetAxisRaw("Vertical") != 0 && jumping == true){
                        PlayerModel.GetComponent<Animator>().Play("jumpAnim"); 
                    }

                    else{
                        jumping = false;
                        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")){
                            if(ThrowScript.sprinting == true){
                                PlayerModel.GetComponent<Animator>().Play("sprintAnim");
                            }
                            else if(ThrowScript.sprinting == false && ThrowScript.gasAnim == false){
                                PlayerModel.GetComponent<Animator>().Play("joggingAnim");
                            }

                            if(ThrowScript.gasAnim == true){
                                PlayerModel.GetComponent<Animator>().Play("crouchwalkForwardAnim");
                            }
                        }
                        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0){
                            if(ThrowScript.sprinting == true){
                                PlayerModel.GetComponent<Animator>().Play("sprintAnim");
                            }
                            else if(ThrowScript.sprinting == false && ThrowScript.gasAnim == false){
                                PlayerModel.GetComponent<Animator>().Play("joggingAnim");
                            }

                            if(ThrowScript.gasAnim == true){
                                PlayerModel.GetComponent<Animator>().Play("crouchwalkForwardAnim");
                            }
                        }

                        if(Input.GetKeyUp("w") || Input.GetKeyUp("a") || Input.GetKeyUp("s") || Input.GetKeyUp("d")){
                            PlayerModel.GetComponent<Animator>().Play("idleAnim");
                        }
                        if(ThrowScript.Skill2AnimCheck == false && ThrowScript.Skill1AnimCheck == false && BasicAttack1.basicAttack == false && jumping == false){
                            if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0){
                                PlayerModel.GetComponent<Animator>().Play("idleAnim");
                            }
                        }
                    }
                }
            }
        }
        else if(BasicAttack1.hasGun == true && BasicAttack1.isReloading == false){
            if(BasicAttack1.basicAttack == false){
                if (Input.GetKey("w") && jumping == true || Input.GetKey("a") && jumping == true || Input.GetKey("s") && jumping == true || Input.GetKey("d") && jumping == true){
                    PlayerModel.GetComponent<Animator>().Play("jumpAnim");
                }
                if(Input.GetAxisRaw("Horizontal") != 0 && jumping == true || Input.GetAxisRaw("Vertical") != 0 && jumping == true){
                    PlayerModel.GetComponent<Animator>().Play("jumpAnim"); 
                }

                else{
                    jumping = false;
                    if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")){
                        if(ThrowScript.sprinting == true){
                            PlayerModel.GetComponent<Animator>().Play("sprintAnim");
                        }
                        else if(ThrowScript.sprinting == false && ThrowScript.gasAnim == false){
                            PlayerModel.GetComponent<Animator>().Play("gunWalkingAnim");
                        }

                        if(ThrowScript.gasAnim == true){
                            PlayerModel.GetComponent<Animator>().Play("crouchwalkForwardAnim");
                        }
                    }
                    if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0){
                        if(ThrowScript.sprinting == true){
                            PlayerModel.GetComponent<Animator>().Play("sprintAnim");
                        }
                        else if(ThrowScript.sprinting == false && ThrowScript.gasAnim == false){
                            PlayerModel.GetComponent<Animator>().Play("gunWalkingAnim");
                        }

                        if(ThrowScript.gasAnim == true){
                            PlayerModel.GetComponent<Animator>().Play("crouchwalkForwardAnim");
                        }
                    }

                    if(Input.GetKeyUp("w") || Input.GetKeyUp("a") || Input.GetKeyUp("s") || Input.GetKeyUp("d")){
                        PlayerModel.GetComponent<Animator>().Play("gunIdleAnim");
                    }
                    if(ThrowScript.Skill2AnimCheck == false && ThrowScript.Skill1AnimCheck == false && BasicAttack1.basicAttack == false && jumping == false){
                        if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0){
                            PlayerModel.GetComponent<Animator>().Play("gunIdleAnim");
                        }
                    }
                }
            }
        }
        else if(BasicAttack1.basicAttack == true){
            Debug.Log("No Movement");
        }
        
    }
}


