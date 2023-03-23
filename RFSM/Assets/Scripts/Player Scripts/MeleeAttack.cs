using UnityEngine.EventSystems;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public Collider weaponCollider;
    public Animator PlayerAnim;



    // Im creating combos
    //declaration of vars
    public float coolDownTime = 0.8f;
    private float nextFireTime = 0f;
    public static int noOfClicks = 0;
    float lastClickTime = 0;
    float maxComboDelay = 1;
    //end of declaration for combo



    void Start()
    {
        /*// Disable the weapon collider by default */
        weaponCollider.enabled = false;

        PlayerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && PlayerAnim.GetCurrentAnimatorStateInfo(0).IsName("Attacking"))
        {
            PlayerAnim.SetBool("comboHit0", false);
        }
        if (PlayerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && PlayerAnim.GetCurrentAnimatorStateInfo(0).IsName("AttackCombo1"))
        {
            PlayerAnim.SetBool("comboHit1", false);
        }
        if (PlayerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && PlayerAnim.GetCurrentAnimatorStateInfo(0).IsName("AttackCombo2"))
        {
            PlayerAnim.SetBool("comboHit2", false);
        }
        if (PlayerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && PlayerAnim.GetCurrentAnimatorStateInfo(0).IsName("AttackCombo3"))
        {
            PlayerAnim.SetBool("comboHit3", false);
            noOfClicks = 0;
        }

        // cooldown

        if (Time.time - lastClickTime < maxComboDelay)
        {
            noOfClicks = 0;
        }
        if (Time.time > nextFireTime)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            if (Input.GetMouseButtonDown(0))
            {
                OnCLick();
            }
        }
    }

    // Called by an animation event at the end of the attack animation

    //for combo
    void OnCLick()
    {
        lastClickTime = Time.time;
        noOfClicks++;
        // only set comboHit0 to true if this is the first attack or combo
        if (noOfClicks == 1) {
            PlayerAnim.SetBool("comboHit0", true);
        }
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 4); // minimum or maximum range

        //check if number of clicks is larger or equals to 2// Checking if the current animation is done or finish // if it is bool set to false in combo 0
        if (noOfClicks >= 2 || PlayerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && PlayerAnim.GetCurrentAnimatorStateInfo(0).IsName("Attacking"))
    {
            Debug.Log("Attaking anim is done!!");
        PlayerAnim.SetBool("comboHit0", false);
        PlayerAnim.SetBool("comboHit1", true);
    }
    if (noOfClicks >= 3 || PlayerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && PlayerAnim.GetCurrentAnimatorStateInfo(0).IsName("AttackCombo1"))
    {
        PlayerAnim.SetBool("comboHit1", false);
        PlayerAnim.SetBool("comboHit2", true);
    }
    if (noOfClicks >= 4 || PlayerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && PlayerAnim.GetCurrentAnimatorStateInfo(0).IsName("AttackCombo2"))
    {
        PlayerAnim.SetBool("comboHit2", false);
        PlayerAnim.SetBool("comboHit3", true);
    }
}





    public void EnableWeaponCollider(int isEnable)
    {
        // check if char holding sword
        if(weaponCollider != null)
        {
            var col = weaponCollider.GetComponent<Collider>();

            if (col != null)
            {
                if(isEnable == 1)
                {
                    col.enabled = true;
                }
                else
                {
                    col.enabled = false;
                }
            }
        }
    }
     
}
