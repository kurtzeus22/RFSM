using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider healthBar; // for the health bar
    [SerializeField]
    private float HP = 100;
    public Animator animator;


    void LateUpdate()
    {
        healthBar.value = HP; // set tha value for the health bar 
    }

    public void TakeDamage(float damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            //play death animation animator.SetTrigger("Die");
            print("Enemy Dieeeee!!!");
            HP = 0; 

        }else{
            //play hit animator.SetTrigger("Damage");
            print("Enemy was Hitttt!!!");
        }
    }
}
