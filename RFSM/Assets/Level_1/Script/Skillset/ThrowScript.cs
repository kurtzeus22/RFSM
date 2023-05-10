using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThrowScript : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public Transform attackPoint;
    public GameObject objectToThrow;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode skill1 = KeyCode.Alpha1;
    public KeyCode skill2 = KeyCode.Alpha2;
    public KeyCode skill3 = KeyCode.Alpha3;
    public KeyCode skill4 = KeyCode.Alpha4;
    public float throwForce;
    public float throwUpwardForce;

    //Player Model
    public GameObject PlayerModelBoy;
    public GameObject PlayerModelGirl;
    GameObject PlayerModel;
    public GameObject TrailRenderer;

    //Skill 1
    [Header("Skill 1")]
    public GameObject Cursor; //Skill Indicator
    public GameObject HammerKnock; //Hammer Range
    public float Skill1_Length = 1f; //Length and Duration of Hammer Knock
    public static bool hammerdown;
    public static bool Skill1AnimCheck;
    public GameObject Skill1HitEffect;
    public Transform PlayerPosition;

    //Skill 2
    [Header("Skill 2")]
    public GameObject Cursor2; //Skill Indicator
    public GameObject Explosion; //Explosion and Range
    public float Skill2_Length = 2f; //Length of Explosion
    bool readyToThrow;
    public static bool Skill2AnimCheck;
    public GameObject gun;
    public Transform Skill2Position;
    

    //Skill 3
    [Header("Skill 3")]
    public GameObject GasTrail; //Trail Activator (Behind the Player)
    public float Skill3_Length = 5f; //Length and Duration of Gas Trail
    public static bool gasAnim;

    //Skill 4
    [Header("Skill 4")]
    public GameObject InviBody; //Activation of Invisible Body
    public float Skill4_Length = 5f; //Length and Duration of having an Invi Body
    public static bool sprinting;

    private void Start()
    {
        if(Movement.PlayerSkin == 1){
            PlayerModel = PlayerModelBoy;
            PlayerModelGirl.SetActive(false);
        }
        else if(Movement.PlayerSkin == 2){
            PlayerModel = PlayerModelGirl;
        }
        Skill1AnimCheck = false;
        readyToThrow = true;
        Skill2AnimCheck = false;
        Cursor.SetActive(false);
        Cursor2.SetActive(false);
        GasTrail.SetActive(false);
        TrailRenderer.GetComponent<TrailRenderer>().enabled=false; 
    }

    private void Update()
    {
        //Skill2
        if(Input.GetKey(skill2) || Input.GetButton("GPSkill2")){
            Cursor2.SetActive(true);
        }
        if(Input.GetKeyUp(skill2) && readyToThrow && totalThrows > 0 || Input.GetButtonUp("GPSkill2")  && readyToThrow && totalThrows > 0)
        {
            gun.SetActive(false);
            Skill2AnimCheck = true;
            Cursor2.SetActive(false);
            PlayerModel.GetComponent<Animator>().Play("throwAnim_down");
            PlayerModel.GetComponent<Animator>().Play("throwAnim_up");
            Throw();
            StartCoroutine(Explode());
            StartCoroutine(BombTimer());
        }
        

        //Skill1
        if(Input.GetKey(skill1) || Input.GetButton("GPSkill1")){
            Skill1AnimCheck = true;
            Cursor.SetActive(true);
        }
        if(Input.GetKeyUp(skill1) || Input.GetButtonUp("GPSkill1")){
            Cursor.SetActive(false);
            StartCoroutine(Hammer());
        }
        //Skill3
        if(Input.GetKeyDown(skill3) || Input.GetButtonUp("GPSkill3")){
            StartCoroutine(Gas());
        }

        //Skkill4
        if(Input.GetKeyDown(skill4) || Input.GetButtonUp("GPSkill4")){
            InviBody.SetActive(false);
            sprinting = true;
            // PlayerModel.GetComponent<Animator>().Play("sprintAnim");
            StartCoroutine(InviChange());
        }



    }

    //Skill 1 Functions
    IEnumerator Hammer(){
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")){
            PlayerModel.GetComponent<Animator>().Play("smashAnim");
            yield return new WaitForSeconds(1f);
            CinemachineShake.isShaking = true;
            yield return new WaitForSeconds(.2f);
            Skill1Hit();
            Skill1AnimCheck = false;
        }
        else {
            PlayerModel.GetComponent<Animator>().Play("smashAnim");
            yield return new WaitForSeconds(1f);
            CinemachineShake.isShaking = true;
            yield return new WaitForSeconds(.2f);
            Skill1Hit();
            Skill1AnimCheck = false;
        }

        Vector3 playerPos = player.transform.position;
        playerPos = new Vector3(playerPos.x, playerPos.y-1, playerPos.z);
        var HammerFall = Instantiate(HammerKnock, playerPos, Quaternion.identity);
        Destroy(HammerFall, Skill1_Length);
    }

    void Skill1Hit(){
        GameObject newSkillHitEffect = Instantiate(Skill1HitEffect, PlayerPosition.position, PlayerPosition.rotation);
        CinemachineShake.isShaking = false;
        // newBurstEffect.Play();
        Destroy(newSkillHitEffect.gameObject, 3f);
    }

    //Skill 2 Functions
    private void Throw()
    {
        readyToThrow = false;

        // instantiate object to throw
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, player.rotation);
        // get rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        // calculate direction
        Vector3 forceDirection = player.transform.forward;
        RaycastHit hit;
        if(Physics.Raycast(player.position, player.forward, out hit, 500f))
        {
            forceDirection = (Skill2Position.position - attackPoint.position).normalized;
        }
        // add force
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;
        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);
        totalThrows--;
        Destroy(projectile, 4f);
        // implement throwCooldown
        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }

    IEnumerator Explode(){
        yield return new WaitForSeconds(2f);
        Skill2AnimCheck = false;
        Vector3 grePos = GameObject.Find("Grenade(Clone)").transform.position;
        grePos = new Vector3(grePos.x-8f, grePos.y, grePos.z);
        var Clonebomb = Instantiate(Explosion, grePos, Quaternion.identity);
        Destroy(Clonebomb, Skill2_Length);
        gun.SetActive(true);
    }

    IEnumerator BombTimer(){
        yield return new WaitForSeconds(2f);
        CinemachineShake.isShaking = true;
        yield return new WaitForSeconds(.75f);
        CinemachineShake.isShaking = false;
    }

    //Skill 3 Functions
     IEnumerator Gas(){
        GasTrail.SetActive(true);
        gasAnim = true;
        yield return new WaitForSeconds(Skill3_Length);
        GasTrail.SetActive(false);
        gasAnim = false;
        
    }

    //Skill 4 Function
    IEnumerator InviChange(){
        TrailRenderer.GetComponent<TrailRenderer>().enabled=true; 
        Movement.speed = 20f;
        yield return new WaitForSeconds(Skill4_Length);
        Movement.speed = 12f;
        InviBody.SetActive(true);
        TrailRenderer.GetComponent<TrailRenderer>().enabled=false; 
        sprinting = false;
        
    }
}
