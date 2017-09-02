using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour {
    [HideInInspector]
    public UnityEngine.AI.NavMeshAgent playerAgent;
    private bool hasInteracted;
    bool isEnemy;
    public float radius = 3f;

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        //isEnemy = gameObject.tag == "Enemy";
        //hasInteracted = false;
        //this.playerAgent = playerAgent;
        //playerAgent.stoppingDistance = 2f;
        //playerAgent.destination = transform.position;
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with base class.");
    }

    void EnsureLookDirection()
    {
        playerAgent.updateRotation = false;
        Vector3 lookDirection = new Vector3(transform.position.x, playerAgent.transform.position.y, transform.position.z);
        playerAgent.transform.LookAt(lookDirection);
        playerAgent.updateRotation = true;

    }
}
