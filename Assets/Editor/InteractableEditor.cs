using UnityEditor;

//Script to set the Editor of an Interactable Object
//True means this script will affect child classes
[CustomEditor(typeof(Interactable),true)]
public class InteractableEditor : Editor
{
    //This function gets called everytime Unity updates the Editor Interface
    public override void OnInspectorGUI(){
        //Variable to save the script
        //Target is another variable that we have acess to when we are inherating from Editor
        //Target is the current selected GameObject we are Inspecting
        //We have to force Target to be the same type as the variable type
        Interactable interactable = (Interactable)target;

        //If the GameObject is Type Of EventOnlyInteractable
        if(target.GetType() == typeof(EventOnlyInteractable)){
            //Create a field on the Editor to set the Prompt Message
            interactable.promptMessage = EditorGUILayout.TextField("Prompt Message", interactable.promptMessage);
            //Set a Warning Message to remember can ONLY use UnityEvents
            EditorGUILayout.HelpBox("EventOnlyInteract can ONLY use UnityEvents.", MessageType.Info);

            //If the GameObject doesn´t have the Script Interaction Event
            if(interactable.GetComponent<InteractionEvent>() == null){
                //Set Use Event to true to add it
                interactable.useEvents = true;
                interactable.gameObject.AddComponent<InteractionEvent>();
            }
        }else{
            base.OnInspectorGUI();
            //If the GameObject Use Events we set the component Interaction Event (script) to itself
            if(interactable.useEvents){
                //We have to check if the GameObject doesn´t have the Script to prevent a loop
                if(interactable.GetComponent<InteractionEvent>() == null){
                    //Add the script to the Game Object
                    interactable.gameObject.AddComponent<InteractionEvent>();
                }
            }else{
                //If we are not using Events on the GameObject
                if(interactable.GetComponent<InteractionEvent>() != null){
                    //Destroy the Script of the GameObject
                    DestroyImmediate(interactable.GetComponent<InteractionEvent>());
                }
            }
        }

        
    }
}
