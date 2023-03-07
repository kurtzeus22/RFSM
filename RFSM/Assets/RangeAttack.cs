using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    public bool pressFire = false;
    public Transform attackSpawnPoint;
    public GameObject attackPrefab;
    public float bulletSpeed = 10;


    public void fireAttack()
    {
        var fire = Instantiate(attackPrefab, attackSpawnPoint.position, attackSpawnPoint.rotation);
        fire.GetComponent<Rigidbody>().velocity = attackSpawnPoint.forward * bulletSpeed; 
    }

    

}
