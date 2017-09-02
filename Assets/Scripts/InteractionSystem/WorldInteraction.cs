using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Apply this script to the player object.  It controls the interactions with the interactable objects in
//the world.  It uses left mouse button to focus an item, right mouse button to interact with the interactable, if focused,
//or focus it and then interact with the interactable, escape to clear the focus.

public class WorldInteraction : MonoBehaviour {

    UnityEngine.AI.NavMeshAgent playerAgent;

    public Interactable focusItem;
    
	void Start () {

        playerAgent = GetComponent<NavMeshAgent>();
        focusItem = null;
	}
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit interactionInfo;

            if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
            {
                playerAgent.updateRotation = true;
                Interactable interactable = interactionInfo.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
                else
                {
                    RemoveFocus();
                }
            }
        }

        if (Input.GetMouseButtonDown(1) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit interactionInfo;

            if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
            {
                playerAgent.updateRotation = true;
                Interactable interactable = interactionInfo.collider.GetComponent<Interactable>();
                if (interactable != null  && interactable != focusItem)
                {
                    SetFocus(interactable);
                }
                else if (interactable == null)
                {
                    RemoveFocus();
                }
            }

            if (focusItem != null)
            {
                float distance = Vector3.Distance(focusItem.transform.position, transform.position);
                if (distance <= focusItem.radius)
                {
                    focusItem.Interact();
                }
                else
                {
                    Debug.Log("Too far to interact.");
                }
            }
            else
            {
                Debug.Log("Nothing to interact with: ");
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            RemoveFocus();
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focusItem)
        {
            if (focusItem != null)
            {
                focusItem.OnDefocused();
            }
            focusItem = newFocus;
        }
        focusItem.OnFocused();
    }

    void RemoveFocus()
    {
        if (focusItem != null)
            focusItem.OnDefocused();

        focusItem = null; 
    }
}
