using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayerController : MonoBehaviour
{
    public GameObject crosshair; //crosshair position
    public GameObject nonAimGun; //gun when it is not aimed
    public CharacterController controller; //player controller
    public float speed = 12f; //speed of the user
    public bool skillTypeIsGun; //skillType 3 para gun
    void Start() {
        crosshair.SetActive(false);
        nonAimGun.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(skillTypeIsGun == true){
            if(Movement.isAiming == true){
                crosshair.SetActive(false);
                nonAimGun.SetActive(false);
                float x = Input.GetAxis("Horizontal");
                float z = Input.GetAxis("Vertical");

                Vector3 move = transform.right * x + transform.forward * z;

                controller.Move(move * speed * Time.deltaTime);
            }
            else if(Movement.isAiming == false){
                crosshair.SetActive(false);
                nonAimGun.SetActive(true);
            }
        }
        
    }
}
