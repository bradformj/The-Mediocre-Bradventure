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
 
            GetFocus();
            if(focusItem != null)
                GetInteraction(focusItem); //fix focus removal in every focus action

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            RemoveFocus();

        }

    }

    void GetInteraction(Interactable focusObject)
    {
        if (focusObject != null)
        {
            Debug.Log(focusObject.tag + " " + focusObject.name + " is the target of an interaction.");
        }
        else
        {
            Debug.Log("Nothing interacted.");
        }
    }

    void GetFocus()
    {
        if (focusItem != null)
            RemoveFocus();

        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;

        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            playerAgent.updateRotation = true;
            Interactable focusObject = interactionInfo.collider.GetComponent<Interactable>();

            if (focusObject != null)
            {
                if (focusObject.tag == "Enemy")
                {
                    Debug.Log("Enemy " + focusObject.name + " focused");
                    focusItem = focusObject;
                }
                else if (focusObject.tag == "Interactable Object")
                {
                    Debug.Log("Item " + focusObject.name + " focused");
                    focusItem = focusObject;
                }
            
            }
        }
        else
            focusItem = null;

    }

    void RemoveFocus()
    {
        focusItem = null;
    }
}
