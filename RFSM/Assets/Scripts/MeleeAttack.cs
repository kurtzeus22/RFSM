using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public Collider weaponCollider;
    public Animator PlayerAnim;
    void Start()
    {
        // Disable the weapon collider by default
        weaponCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) // Check if left mouse button is clicked
        {

            weaponCollider.enabled = true;// Enable the weapon collider when attacking

            PlayerAnim.SetTrigger("isAttacking"); // Trigger the "Attack" animation
            // can also add code to handle damage to enemies, sound effects, etc.
        }
    }
   
    // Called by an animation event at the end of the attack animation
    public void OnAttackAnimationEnd()
    {
        // Disable the weapon collider when the attack animation ends
        weaponCollider.enabled = false;
    }
}
