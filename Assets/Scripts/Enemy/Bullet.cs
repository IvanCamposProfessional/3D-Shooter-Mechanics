using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Function to check the collision of the bullet
    private void OnCollisionEnter(Collision collision){
        //Variable to save the transform of the GameObject the bullet hits with
        Transform hitTransform = collision.transform;
        //If the bullet hits the Player
        if(hitTransform.CompareTag("Player")){
            Debug.Log("Hit Player");
            //Make the player take damage
            //We call the PlayerHealth TakeDamage from the Player
            hitTransform.GetComponent<PlayerHealth>().TakeDamage(10);
        }
        //Destroy the bullet when it collision with something
        Destroy(gameObject);
    }
}
