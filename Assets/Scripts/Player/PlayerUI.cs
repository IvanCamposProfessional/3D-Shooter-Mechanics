using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    //Variable for the Text of the Prompt Message of the Interactable
    [SerializeField]
    private TextMeshProUGUI promptText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Function that updates the UI text getting a prompt message
    public void UpdatePromptText(string promptMessage){
        promptText.text = promptMessage;
    }
}
