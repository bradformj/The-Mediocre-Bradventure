using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignPost : ActionItem {

    public string[] dialogue;

    public override void Interact()
    {
        base.Interact();
        DialogueSystem.Instance.AddNewDialogue(dialogue, "Sign");
        Debug.Log("Interacting with Sign Post.");
    }
    
}
