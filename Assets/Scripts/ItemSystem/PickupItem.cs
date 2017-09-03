using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactable {

    public Item item; //can we automate this using the Load or something rather than having to drag it in every time we instantiate an item??? seems limiting...

    public override void Interact()
    {
        
        base.Interact();

        //Debug.Log("Interacting with pickupitem.");

        PickUp();

        //Debug.Log("Finished interacting with pickup item.");
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
