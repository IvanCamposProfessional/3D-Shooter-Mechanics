using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    //Create a variable to save the CharacterController on the GameObject Player
    private CharacterController controller;
    //Create a variable to save the on movement velocity of the player
    private Vector3 playerVelocity;
    //Variable to check if the Player is on the floor
    private bool isGrounded;
    //Create a variable to define the player movement speed and initialize it to 5f
    public float speed = 5f;
    //Variable to set the gravity that apllies to the Player
    //Variable initialized with the gravity of the Earth
    public float gravity = -9.8f;
    //Variable to set the height that the Player can jump
    public float jumpHeight = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize the variable controller with the attribute on the GameObject
        controller = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {
        //Check every frame if the Player Is Grounded
        isGrounded = controller.isGrounded;
    }

    //Function to make the player run
    public void Run(){
        speed = 7f;
    }

    //Function to make the player stop running
    public void StopRunning(){
        speed = 5f;
    }

    //Define the function which recives the inputs for our InputManager.cs and then apply them to our CharacterController
    public void ProcessMove(Vector2 input){
        //Create a variable to set the move direction on the Player and initialize it to zero
        Vector3 moveDirection = Vector3.zero;
        //Set the MoveDirectio x axis to the input we receive x
        moveDirection.x = input.x;
        //Set the MoveDirection z axis to the input we receive y because input is a 2D vector and MoveDirection is a 3D Vector,
        //We translate the vertical movement to forward/backward movement
        moveDirection.z = input.y;
        //Set the Move funcion of the CharacterController with the Move Direction and then apply the speed to the Movement
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        //Apply the gravity to the Player Velocity y axis
        playerVelocity.y += gravity * Time.deltaTime;
        //If the Player is on the floor and the y axis of the Player Velocity is bellow 0 (it means that the Player is On the Floor)
        if(isGrounded && playerVelocity.y < 0){
            //Set the y axis to -2 because we dont want that value decrease all the time
            //We want it constantly on -2 because if it decreases all the time we can´t jump
            playerVelocity.y = -2f;
        }
        //Apply the Player Velocitiy to the Player applying it to the Charracter Controller
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump(){
        //If player is On the Floor
        if(isGrounded){
            //We set the Y axis of Player Velocity on the JumpHeight * -3 * gravity set to the player
            //-3f is to set the velocity greater than the gravity apllied to the Player
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
        }
    }
}
