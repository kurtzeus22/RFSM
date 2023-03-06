using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFireScript : MonoBehaviour
{
    public float life = 3;

    void Awake()
    {
        Destroy(gameObject, life);
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check if the collision object is the player
        {
            Destroy(gameObject); // Destroy the bullet
            print("Bullet hit player!");
        }
    }
}

