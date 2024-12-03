using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    //Create a variable to save the active state the enemy is currently in
    public BaseState activeState;

    public void Initialise(){
        ChangeState(new PatrolState());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Perform every frame the active state
        if(activeState != null){
            activeState.Perform();
        }
    }

    //Function to change the state of the enemy passing the new state we want to enter
    public void ChangeState(BaseState newState){
        //Check if the active state is not empty
        if(activeState != null){
            //Run clean up on active state
            activeState.Exit();
        }

        //Change into a new state
        activeState = newState;

        //Fail-safe null check to make sure newState wasn´t null
        if(activeState != null){
            //Setup new state
            //Set the State Machine on the Active State to this script
            activeState.stateMachine = this;
            //Assign the enemy on the Active State Class
            activeState.enemy = GetComponent<Enemy>();
            //Assign state enemy class
            activeState.Enter();
        }
    }
}
