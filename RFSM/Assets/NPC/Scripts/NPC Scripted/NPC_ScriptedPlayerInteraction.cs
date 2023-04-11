using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_ScriptedPlayerInteraction : MonoBehaviour
{
    bool hasrun = false;
    public GameObject NPC;
    public void OnCollisionStay(Collision other)
    {
        if(hasrun == false){
            if (other.gameObject.name == "InteractionBox")
            {
                Debug.Log("Collision detected with Player!");
                NPC.GetComponent<ScriptedWaypoint>().CallOut();
            }
        }

            float interactRange = 3f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            if(hasrun == false){
                foreach (Collider collider in colliderArray){
                    if (collider.TryGetComponent(out NPC_ScriptedInteraction NPCinteractible )) {
                        NPCinteractible.Interact();
                        hasrun = true;
                    }
                }
            }

       
    }
}

