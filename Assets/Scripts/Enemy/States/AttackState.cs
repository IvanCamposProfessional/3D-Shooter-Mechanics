using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    //Variable to set the calculate with what timming will the enemy move
    public float moveTimer;
    //how long the enemy will remain in attack state before they start searching for the player
    private float losePlayerTimer;

    public override void Enter(){

    }

    public override void Perform(){
        //Check while performing the state if the enemy can see the player
        //The variable enemy is on the BaseState class that this state inherits
        if(enemy.CanSeePlayer()){
            //Lock the lose player timer to 0
            losePlayerTimer = 0;
            //Increase move timer
            moveTimer += Time.deltaTime;
            //Make the move of the enemy random
            if(moveTimer > Random.Range(3, 7)){
                //Move the enemy to a random location
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                //Reset move timer
                moveTimer = 0;
            }
        //The enemy can`t see the player    
        }else{
            //Increase lose player timer
            losePlayerTimer += Time.deltaTime;

            //If the lose player timer is greater than 8 seconds
            if(losePlayerTimer > 8){
                //Change to the Search State
                //The variable stateMachine is on the BaseState class that this state inherits
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }

    public override void Exit(){

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
