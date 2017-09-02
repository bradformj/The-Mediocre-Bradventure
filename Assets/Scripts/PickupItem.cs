using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactable {

    public Item item;

    public override void Interact()
    {
        
        base.Interact();

        Debug.Log("Interacting with pickupitem.");

        PickUp();

        Debug.Log("Finished interacting with pickup item.");
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.itemName + ".");
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }


}
