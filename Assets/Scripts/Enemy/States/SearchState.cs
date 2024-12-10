using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : BaseState
{
    //Variable to calculate the time that the Enemy will search the Player
    private float searchTimer;

    //Variable to set the calculate with what timming will the enemy move
    public float moveTimer;

    public override void Enter(){
        //On Enter the state, the enemy will move to the last position where has seen tha Player
        enemy.Agent.SetDestination(enemy.LastKnowPos);
    }

    public override void Perform(){
        //If the enemy can see the player
        if(enemy.CanSeePlayer()){
            //Change the enemy state to Attack State
            stateMachine.ChangeState(new AttackState());
            //Reset the search timer
            //searchTimer = 0;
        }

        //If the enemy is on the last position where has seen the Player
        if(enemy.Agent.remainingDistance < enemy.Agent.stoppingDistance){
            //Increment the Search Timer
            searchTimer += Time.deltaTime;

            //Increase move timer
            moveTimer += Time.deltaTime;

            //Make the move of the enemy random
            if(moveTimer > Random.Range(2, 5)){
                //Move the enemy to a random location
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                //Reset move timer
                moveTimer = 0;
            }

            //If the enemy was searching the Player for 5 seconds
            if(searchTimer > 10){
                //Change the state to Patrol
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }

    public override void Exit(){

    }
}
