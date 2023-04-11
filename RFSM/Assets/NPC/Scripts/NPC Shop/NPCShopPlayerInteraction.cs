using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShopPlayerInteraction : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        float shopinteractRange = 3f;
            Collider[] colliderShopArray = Physics.OverlapSphere(transform.position, shopinteractRange);
        foreach (Collider collider in colliderShopArray){
                if (collider.TryGetComponent(out NPCShopInteraction NPCShopInteractible )) {
                    NPCShopInteractible.ShowButton();
                }
            }

        if(Input.GetKeyDown(KeyCode.B)) {
            // float shopinteractRange = 3f;
            // Collider[] colliderShopArray = Physics.OverlapSphere(transform.position, shopinteractRange);
            foreach (Collider collider in colliderShopArray){
                if (collider.TryGetComponent(out NPCShopInteraction NPCShopInteractible )) {
                    NPCShopInteractible.ShopInteract();
                }
            }
        }
    }
}
