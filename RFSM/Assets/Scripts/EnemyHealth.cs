using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float HP = 100;
    public Animator animator;
    public void TakeDamage(float damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            //play death animation animator.SetTrigger("Die");
            print("Enemy Dieeeee!!!");

        }else{
            //play hit animator.SetTrigger("Damage");
            print("Enemy was Hitttt!!!");
        }
    }
}
