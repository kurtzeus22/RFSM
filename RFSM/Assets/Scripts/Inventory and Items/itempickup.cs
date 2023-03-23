using System.Collections;
using System.Collections.Generic;
using System.Net.Configuration;
using UnityEngine;

public class itempickup : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();
        PickUP();
    }
    void PickUP()
    {
        Debug.Log("Picking up " + item.name);
        // add this to inventory
        bool wasPickUp = Inventory.Instance.Add(item); 
        // remove game object
        if(wasPickUp)
        {
            Destroy(gameObject);
        }
        

    }
}
