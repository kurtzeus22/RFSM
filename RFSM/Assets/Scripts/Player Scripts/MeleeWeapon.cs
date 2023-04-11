using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [SerializeField]
    private float damageAmount = 10f; // The amount of damage the weapon will apply to enemies
    public LayerMask enemyLayer; // The layer that enemies are on

    private void OnTriggerEnter(Collider other)
    {

        if (enemyLayer == (enemyLayer | (1 << other.gameObject.layer))) // Check if the other object is on the enemy layer
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>(); // Get the enemy health component

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount); // Apply damage to the enemy
            }
        }
    }
}
