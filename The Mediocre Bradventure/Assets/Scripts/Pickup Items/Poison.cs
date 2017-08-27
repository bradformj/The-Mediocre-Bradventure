using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : PickupItem {

    public string[] dialogue;

    public override void Interact()
    {
        base.Interact();
        DialogueSystem.Instance.AddNewDialogue(dialogue, "Poison!!!");
        Debug.Log("Interacting with Poison.");
    }

}
