using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAdd : MonoBehaviour
{
    public GameObject orb;
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "Player"){
            if(Health.health < 5){
                Health.health = Health.health + 1;
                Debug.Log("Health +1 dapat");
                Destroy(orb);
                Health.isFrom1Health = true;
            }
            else if(Health.health >= 5){
                //nothing
            }
       }
    }
}
