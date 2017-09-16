using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class BasicAI : MonoBehaviour
    {
        //editor debugging stuff
       //public float charDist;
       //public float charDesiredSpeed;
       //public float charSpeed;
       //public Vector3 targetLocation;
       //public Vector3 desiredLocation;
        
        public NavMeshAgent agent;
        public ThirdPersonCharacter character;

        public enum State
        {
            PATROL,
            CHASE,
        }

        public State state;
        private bool alive;

        //Variables for patrolling
        public GameObject[] waypoints;
        private int waypointInd;
        public float patrolSpeed = .5f;

        //Variables for chasing
        public float chaseSpeed = 1f;
        public GameObject target;

        // Use this for initialization
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

            agent.updatePosition = true;
            agent.updateRotation = false;

            waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
            waypointInd = Random.Range(0, waypoints.Length-1);

            state = BasicAI.State.PATROL;

            alive = true;

            StartCoroutine("FSM"); //start the finite state machine

        }

       //private void Update()
       //{
       //    charDist = Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position);
       //    charDesiredSpeed = agent.desiredVelocity.magnitude;
       //    charSpeed = agent.velocity.magnitude;
       //    targetLocation = agent.destination;
       //    desiredLocation = waypoints[waypointInd].transform.position;
       //
       //}

        IEnumerator FSM()
        {
            while (alive)
            {
                switch (state)
                {
                    case State.PATROL:
                        Patrol();
                        break;
                    case State.CHASE:
                        Chase();
                        break;
                }
                yield return null;
            }
        }

        void Patrol()
        {
            //not sure how to structure this.  I think the enemy game objects should have a collection of waypoints relative to themselves contained in the enemy gameObject
            //at initialization, the BasicAI can find those waypoints in world coordinates and create a collection of new vector3's at those coordinates.
            //Then the enemy can traverse those waypoints.
            
            agent.speed = patrolSpeed;
            if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) >= 2)
            {

                agent.SetDestination(waypoints[waypointInd].transform.position); //this waypoint has to be at y=0 (or on the navmesh, maybe???) or the navmesh has a heart attack.
                character.Move(agent.desiredVelocity, false, false);
            }
            else if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) <= 2)
            {
                //Debug.Log("You reached the destination, finding a new one.");
                waypointInd = Random.Range(0, waypoints.Length-1);
            }
            else
            {
                Debug.Log("Default Patrol output.  This should not be happening.");
                character.Move(Vector3.zero, false, false);
            }
        }

        void Chase()
        {
            agent.speed = chaseSpeed;
            agent.SetDestination(target.transform.position); //this waypoint has to be at y=0 (or on the navmesh, maybe???) or the navmesh has a heart attack.

            character.Move(agent.desiredVelocity, false, false);
        }

        private void OnTriggerEnter(Collider coll)
        {
            if (coll.tag == "Player")
            {
                state = BasicAI.State.CHASE;
                target = coll.gameObject;
            }
        }

        private void OnTriggerExit(Collider coll)
        {
            if (coll.tag == "Player")
            {
                state = BasicAI.State.PATROL;
                target = null;
            }
        }
    }
}

