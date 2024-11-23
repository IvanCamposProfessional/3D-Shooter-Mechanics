using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    //Variable for the camera
    private Camera cam;
    //Variable for the ray distance
    [SerializeField]
    private float distance = 3f;
    //Variable that stores the Layer Mask to check with the Ray Cast
    [SerializeField]
    private LayerMask mask;
    //Variable for the Player UI manager script
    private PlayerUI playerUI;
    //Variable for the Player Input Manager
    private InputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize the variable cam with the cam on the attached script Player Look
        cam = GetComponent<PlayerLook>().cam;
        //Initialize the variable with the script PlayerUI attached to the Player
        playerUI = GetComponent<PlayerUI>();
        //Initialize the variable with the Input Manager attached to the Player
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Empty the text when we are not looking to the GameObject
        playerUI.UpdatePromptText(string.Empty);

        //Create a ray with the starting position on the camera and the direction is forward
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        //Debug to see the ray
        //Debug.DrawRay(ray.origin, ray.direction * distance);

        //Variable to store the collision of the ray info
        RaycastHit hitInfo;

        //Start a Raycast with the ray we created and it returns the collision on Hit Info
        //The ray goes forward the distance we define
        //If its RayCasting
        if(Physics.Raycast(ray, out hitInfo, distance)){
            //If the GameObject that collided with the ray has the Script Interactable
            if(hitInfo.collider.GetComponent<Interactable>() != null){
                //Temporal variable for the Interacatable script on the Hit Info Collider
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                //Use the funcion to Update the Prompt Text passing the Prompt Message on the Interactable Script
                playerUI.UpdatePromptText(interactable.promptMessage);

                //If we Trigger the Interact Button on defined on script Input Manager variable onFoot
                if(inputManager.onFoot.Interact.triggered){
                    interactable.BaseInteract();
                }
            }
        }
    }
}
