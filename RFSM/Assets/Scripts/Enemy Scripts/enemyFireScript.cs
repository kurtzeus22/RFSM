using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFireScript : MonoBehaviour
{
    public float life = 3;
    // put damage here
    [SerializeField]
    private float damageAmount = 10f; // The amount of damage the weapon will apply to Player

    void Awake()
    {
        Destroy(gameObject, life);
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check if the collision object is the player
        {
            Destroy(gameObject); // Destroy the bullet
            
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
           
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount); // Apply damage to the Player
                print("Bullet hit player!, Player got damage = " + damageAmount);
            }


        }
    }
}

