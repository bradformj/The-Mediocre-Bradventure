using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour {
    [HideInInspector]
    public UnityEngine.AI.NavMeshAgent playerAgent;
    private bool hasInteracted = false;
    public float radius = 3f;
    bool isFocus = false;
    public Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void OnFocused()
    {
        isFocus = true;
        FocusIndicate();
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        UnfocusIndicate();
        hasInteracted = false;
    }

    public virtual void FocusIndicate()
    {
         //create some indicator of being focused, like a green or red circle under the interactable.
    }

    public virtual void UnfocusIndicate()
    {
        //create some indicator of being focused, like a green or red circle under the interactable.
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with base class.");
        hasInteracted = true;
    }

    void EnsureLookDirection()
    {
        //rotate the player to look at whatever it is that he/she is interacting with

        //playerAgent.updateRotation = false;
        //Vector3 lookDirection = new Vector3(transform.position.x, playerAgent.transform.position.y, transform.position.z);
        //playerAgent.transform.LookAt(lookDirection);
        //playerAgent.updateRotation = true;
    }
}
