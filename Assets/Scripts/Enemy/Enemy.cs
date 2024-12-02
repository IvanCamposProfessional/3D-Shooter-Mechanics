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

    // Start is called before the first frame update
    void Start()
    {
        //Initialize State Machine
        stateMachine = GetComponent<StateMachine>();
        //Initialize private agent
        agent = GetComponent<NavMeshAgent>();
        //Initialize the state machine
        stateMachine.Initialise();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
