using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour {
    UnityEngine.AI.NavMeshAgent playerAgent;

    GameObject focusItem;
    
	
	void Start () {

        playerAgent = GetComponent<NavMeshAgent>(); 

	}
	
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            //Check if we hit an interractable
            //if we did set that item as our focus.

            focusItem = GetFocus();

        }

        if (Input.GetMouseButtonDown(1) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()){
            //Check to see if we hit an interractable
            //if we did, set that item as our focus and interact

            focusItem = GetFocus();
            GetInteraction(focusItem);
        }

    }

    void GetInteraction(GameObject focusObject)
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

    GameObject GetFocus()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;

        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            playerAgent.updateRotation = true;
            GameObject focusObject = interactionInfo.collider.gameObject;
            if (focusObject.tag == "Enemy")
            {
                Debug.Log("Enemy " + focusObject.name + " focused");
                return focusObject;
            }
            else if (focusObject.tag == "Interactable Object")
            {
                Debug.Log("Item " + focusObject.name + " focused");
                return focusObject;
            }
            else
            {
                Debug.Log("Item focused was neither enemy nor interactabl.");
                return focusObject;
            }
        }
        else
            return null;

    }
}
