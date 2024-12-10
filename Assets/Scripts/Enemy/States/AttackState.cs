using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    //Variable to set the calculate with what timming will the enemy move
    public float moveTimer;
    //How long the enemy will remain in attack state before they start searching for the player
    private float losePlayerTimer;
    //Variable to set the calculate with what timming will the enemy shoot
    private float shotTimer;

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
            //Increase shot timer
            shotTimer += Time.deltaTime;
            //Make the enemy look at the Player when is attacking
            enemy.transform.LookAt(enemy.Player.transform);

            //It means that if the timer is greater than the fire rate the enemy can shoot
            //That is the cadence of the weapon
            if(shotTimer > enemy.fireRate){
                Shoot();
            }

            //Make the move of the enemy random
            if(moveTimer > Random.Range(3, 7)){
                //Move the enemy to a random location
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                //Reset move timer
                moveTimer = 0;
            }

            //Save on perform the last position the enemy can see the player
            enemy.LastKnowPos = enemy.Player.transform.position;
        //The enemy can`t see the player    
        }else{
            //Increase lose player timer
            losePlayerTimer += Time.deltaTime;

            //If the lose player timer is greater than 8 seconds
            if(losePlayerTimer > 5){
                //Change to the Search State
                //The variable stateMachine is on the BaseState class that this state inherits
                stateMachine.ChangeState(new SearchState());
            }
        }
    }

    public override void Exit(){

    }

    //Function  to define the logic that will the enemy perform when is shooting on attack state
    public void Shoot(){
        //Store a reference to the gun barrrel
        Transform gunbarrel = enemy.gunBarrel;
        //Instantiate a new bullet from the transform of the gun barrell
        //Resources is a unity reserved name folder that can be referenced on scripts
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, gunbarrel.position, enemy.transform.rotation);
        //Calculate the direction to the player
        Vector3 shootDirection = (enemy.Player.transform.position - gunbarrel.transform.position).normalized;
        //Add force to the RigidBody of the Bullet
        //We make the random quaternion to modify de 100% accurate of the enemy to a random range
        bullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-3f, 3f), Vector3.up) * shootDirection * 40;
        //Reset the shoot timer
        shotTimer = 0;
    }
}
