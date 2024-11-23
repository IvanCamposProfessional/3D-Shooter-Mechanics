using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Make it abstract because we are going to make subclasses
public abstract class Interactable : MonoBehaviour
{
    //The message is going to be shown when you aproach the object
    public string promptMessage;

    //This function will be called from our player
    public void BaseInteract(){
        Interact();
    }

    public virtual void Interact(){
        //This is a template function to be overriden by our subclasses
    }
}
