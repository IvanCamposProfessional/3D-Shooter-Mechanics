using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Make it abstract because we are going to make subclasses
public abstract class Interactable : MonoBehaviour
{
    //Variable to add or remove an InteractionEvent component to this GameObject
    public bool useEvents;
    //The message is going to be shown when you aproach the object
    public string promptMessage;

    //This function will be called from our player
    public void BaseInteract(){
        //If we are using Events System
        if(useEvents){
            //Invoke the function OnInteract on Interaction Event
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        }
        Interact();
    }

    public virtual void Interact(){
        //This is a template function to be overriden by our subclasses
    }
}
