using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //Variable to set the enemy health
    public float health = 100f;
    //Instance to the State Machine we want to use
    private StateMachine stateMachine;
    //Instance of the Navigation Agent of the enemy
    private NavMeshAgent agent;
    //Variable to reference the player
    private GameObject player;
    //Variable to save the last known position of the Player
    private Vector3 lastKnowPos;
    //Public Last Known Position to manipulate it
    //Create a Setter to change the value
    public Vector3 LastKnowPos {  get => lastKnowPos; set => lastKnowPos = value; }
    //Public Agent to manipulate it
    public NavMeshAgent Agent { get => agent; }
    //Public Player to use it in the states
    public GameObject Player { get => player; }
    //Variable to set up the path that the enemy will follow
    public Path path;
    [Header("Sight Values")]
    //Variable to set the enemy sight distance
    public float sightDistance = 20f;
    //Variable to set the enemy field of view
    public float fieldOfView = 85f;
    //Variable to set the eye height of the enemy
    public float eyeHeight;
    [Header("Weapon Values")]
    //Variable to save the position of the gun barrel on the Enemy GameObject
    public Transform gunBarrel;
    //Variable to set the fire rate of the Enemy
    //We are defining that is a Range only between 0.1 and 10
    [Range(0.1f,10f)]
    public float fireRate;
    //String to save the current state enemy is on
    //Serialize Field is just for debbuging purposes
    [SerializeField]
    private string currentState;

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
        //Debug on the inspector the current state
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

    //Function to take damage
    public void TakeDamage(float damage){
        health -= damage;

        //If the enemy health is less or equal to 0 the enemy dies   
        if(health <= 0){
            Die();
        }
    }

    //When the enemy dies it gets destroyed
    private void Die(){
        Destroy(gameObject);
    }
}
