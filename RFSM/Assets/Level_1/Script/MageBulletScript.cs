using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBulletScript : MonoBehaviour
{
    [Header("Homing Variables")]
    [SerializeField] private float force;
    [SerializeField] private float rotationForce;

    private Rigidbody rb;
    private EnemyFieldOfView eFov;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        eFov = FindObjectOfType<EnemyFieldOfView>();
    }
    private void FixedUpdate()
    {
        if (eFov.canSeeEnemy)
        {
            Vector3 direction = (eFov.enemyRef.transform.position - rb.position).normalized;
            Vector3 rotationAmount = Vector3.Cross(transform.forward, direction);
            rb.angularVelocity = rotationAmount * rotationForce;
            rb.velocity = transform.forward * force;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
