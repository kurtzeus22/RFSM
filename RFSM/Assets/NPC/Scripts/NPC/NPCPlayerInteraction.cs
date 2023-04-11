using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPlayerInteraction : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        float interactRange = 3f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray){
                if (collider.TryGetComponent(out NPCInteraction NPCinteractible )) {
                    NPCinteractible.ShowButton();
                }
            }

        if(Input.GetKeyDown(KeyCode.F)) {
            // float interactRange = 3f;
            // Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray){
                if (collider.TryGetComponent(out NPCInteraction NPCinteractible )) {
                    NPCinteractible.Interact();
                }
            }
        }

        //  if(Input.GetKeyDown(KeyCode.B)) {
        //     float shopinteractRange = 3f;
        //     Collider[] colliderShopArray = Physics.OverlapSphere(transform.position, shopinteractRange);
        //     foreach (Collider collider in colliderShopArray){
        //         if (collider.TryGetComponent(out NPCShopInteraction NPCShopInteractible )) {
        //             NPCShopInteractible.ShopInteract();
        //         }
        //     }
        // }
    }
}
