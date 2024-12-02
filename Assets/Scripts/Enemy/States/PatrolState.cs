using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inherits from BaseState
public class PatrolState : BaseState
{
    //Variable to track wich waypoint we are currently targeting
    public int waypointIndex;
    //Variable to set the time that the enemy will wait on each waypoint
    public float waitTimer;

    public override void Enter(){

    }

    public override void Perform(){
        //Perform the patrol cycle every frame
        PatrolCycle();
    }

    public override void Exit(){

    }

    //Function to set the Patrol Cycle
    public void PatrolCycle(){
        //If the enemy gets to the waypoint
        if(enemy.Agent.remainingDistance < 0.2f){
            //Initialize the wait timer
            waitTimer += Time.deltaTime;

            //Count the time that the enemy waits on the waypoint
            if(waitTimer > 3){
                //If the number of the waypoint we are targeting is less than the total of the waypoints - 1
                //It means that we are not in the last waypoint of the list
                if(waypointIndex < enemy.path.waypoints.Count - 1){
                    //Increase by one the waypoint index
                    waypointIndex++;
                //We reached the last waypoint of the list
                }else{
                    //Reset the waypoint index
                    waypointIndex = 0;
                }

                //Set the destination of the enemy patrol to the waypoint we are targeting
                enemy.Agent.SetDestination(enemy.path.waypoints[waypointIndex].position);
                //Reset the timer when the enemy starts moving to the next waypoint
                waitTimer = 0;
            }
        }
    }
}
