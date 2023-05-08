 using UnityEngine;
 using System.Collections;
 
 public class PlayerJump : MonoBehaviour
 {
     float maxJumpHeight = 3.0f;
     float groundHeight;
     Vector3 groundPos;
     float jumpSpeed = 7.0f;
     float fallSpeed = 12.0f;
     public bool inputJump = false;
     public bool grounded = true;
 
     void Start()
     {
         groundPos = transform.position;
         groundHeight = transform.position.y;
         maxJumpHeight = transform.position.y + maxJumpHeight;
     }
 
     void Update()
     {
         if(Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("GPJump"))
         {
             if(grounded)
             {
                 groundPos = transform.position;
                 inputJump = true;
                 StartCoroutine("Jump");
             }
         }
         if(transform.position == groundPos)
             grounded = true;
         else
             grounded = false;
     }
 
      IEnumerator Jump(){
         while(true)
         {
             if(transform.position.y >= maxJumpHeight)
                 inputJump = false;
             if(inputJump)
                 transform.Translate(Vector3.up * jumpSpeed * Time.smoothDeltaTime);
             else if(!inputJump)
             {
                 transform.Translate(Vector3.down * fallSpeed * Time.smoothDeltaTime);
                 if(transform.position.y < groundPos.y){
                     transform.position = groundPos;
                     StopAllCoroutines();
                 }
             }
          
         yield return new WaitForEndOfFrame();
         }
     }
 }