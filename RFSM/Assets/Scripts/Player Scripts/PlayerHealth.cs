using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider playerHealthBar; // for the health bar
    [SerializeField]
    private float playerHP = 100;
    public Animator playeranimator;


    void LateUpdate()
    {
        playerHealthBar.value = playerHP; // set tha value for the health bar 
    }

    public void TakeDamage(float damageAmount)
    {
        playerHP -= damageAmount;
        if (playerHP <= 0)
        {
            //play death animation animator.SetTrigger("Die");
            print("Player Dieeeee!!!");
            playerHP = 0;

        }
        else
        {
            //play hit animator.SetTrigger("Damage");
            print("Player was Hitttt!!!");
        }
    }
}
