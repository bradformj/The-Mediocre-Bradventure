using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour {

    Animator animator;

    NavMeshAgent agent;

	void Start () {

        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
		
	}
	
	void Update () {

        float speedPercent = agent.velocity.magnitude / agent.speed;

        animator.SetFloat("speedPercent", speedPercent, .1f, Time.deltaTime);

	}
}
