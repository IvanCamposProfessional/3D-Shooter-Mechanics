using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //Instance to the State Machine we want to use
    private StateMachine stateMachine;
    //Instance of the Navigation Agent of the enemy
    private NavMeshAgent agent;
    //Public Agent to manipulate it
    public NavMeshAgent Agent { get => agent; }
    //String to save the current state enemy is on
    //Serialize Field is just for debbuging purposes
    [SerializeField]
    private string currentState;
    //Variable to set up the path that the enemy will follow
    public Path path;
    //Variable to reference the player
    private GameObject player;
    //Variable to set the enemy sight distance
    public float sightDistance = 20f;
    //Variable to set the enemy field of view
    public float fieldOfView = 85f;
    //Variable to set the eye height of the enemy
    public float eyeHeight;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize State Machine
        stateMachine = GetComponent<StateMachine>();
        //Initialize private agent
        agent = GetComponent<NavMeshAgent>();
        //Initialize the state machine
        stateMachine.Initialise();
        //Set the Player variable
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Check every frame if the enemy can see the player
        CanSeePlayer();
        currentState = stateMachine.activeState.ToString();
    }

    //Function to check if the enemy is seeing the player
    public bool CanSeePlayer(){
        //Player null check
        if(player != null){
            //Is the player close enough to be seen?
            if(Vector3.Distance(transform.position, player.transform.position) < sightDistance){
                //Temporal variable to save the player direction
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                //Variable to calculate the angle between the enemy and the player
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);

                //Calculate if the player is on the enemy field of view
                //We are checking if the angle is great or equal to -85 and less of equal to 85
                //because the field of view goes between -85 to 85
                if(angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView){
                    //Raycast to the detect if the vision is getting blocked by any object
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if(Physics.Raycast(ray, out hitInfo, sightDistance)){
                        //If the raycast hits the Player
                        if(hitInfo.transform.gameObject == player){
                            Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
}
