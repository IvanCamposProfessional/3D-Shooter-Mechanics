using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    //Variable for saving the PlayerInput
    private PlayerInput playerInput;
    //Variable for saving the Action OnFoot on PlayerInput
    private PlayerInput.OnFootActions onFoot;
    //Variable for the Motor of the Movement (script)
    private PlayerMotor motor;
    //Variable for the Look of the Camera (script)
    private PlayerLook look;

    void Awake()
    {   
        //Initialize both variables
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        //Initialize the motor with the script on the Player GameObject
        motor = GetComponent<PlayerMotor>();
        //Initialize the look with the script on the Player GameObject
        look = GetComponent<PlayerLook>();

        //We define the funcionalitiy when Jump Action is performed
        //Calculate the Jump with the function on the motor setting a pointer to the callback context called ctx
        onFoot.Jump.performed += ctx => motor.Jump();
    }

    void FixedUpdate()
    {
        //Tell the PlayerMotor to move using the value from our Movement Action
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    void LateUpdate(){
        //Tell the PlayerMotor to look using the value from our Look Action
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    //When the script gets enabled
    private void OnEnable(){
        //Enable the action OnFoot
        onFoot.Enable();
    }

    //When the script gets disabled
    private void OnDisable(){
        //Disable action OnFoot
        onFoot.Disable();
    }
}
