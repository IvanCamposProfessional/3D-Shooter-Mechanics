using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script inherit from Interactable
public class KeyPad : Interactable
{
    //Variable for the door that we want to open
    [SerializeField]
    private GameObject door;
    //Variable to check if we can open the door
    private bool doorOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Override the prompt Interact function on the script Interactable
    public override void Interact(){
        //Change the variable to the opposite value
        doorOpen = !doorOpen;
        //We pass the value of the variable doorOpen to the Animator to trigger the corresponding animation
        door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);
    }
}
