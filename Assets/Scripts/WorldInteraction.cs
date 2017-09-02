using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour {
    UnityEngine.AI.NavMeshAgent playerAgent;

    public Interactable focusItem;
    
	
	void Start () {

        playerAgent = GetComponent<NavMeshAgent>(); 

	}
	
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            
            GetFocus();

        }

        if (Input.GetMouseButtonDown(1) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()){

            
            GetInteraction();
            
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            RemoveFocus();

        }

    }

    void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;

        if(Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            playerAgent.updateRotation = true;
            Interactable focusCheck = interactionInfo.collider.GetComponent<Interactable>();
            if(focusCheck != focusItem)
            {
                focusItem = focusCheck;
            }
        }

        if (focusItem != null)
        {
            Debug.Log(focusItem.tag + " " + focusItem.name + " is the target of an interaction.");
        }
        else
        {
            Debug.Log("Nothing interacted.");
        }
    }

    void GetFocus()
    {

        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;

        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            playerAgent.updateRotation = true;
            focusItem = interactionInfo.collider.GetComponent<Interactable>();
        }
        else
        {
            focusItem = null;
        }
            

    }

    void RemoveFocus()
    {
        focusItem = null;
    }
}
