using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{   
    //Variable to save the current health
    private float health;
    //
    private float lerpTimer;
    //Variable to save the maximum health of the player
    public float maxHealth = 100f;
    //Variable that saves how quickly the delay bar takes to catch up to the one that we inmediatly set
    public float chipSpeed = 2f;
    //Variables to save the Images of the front and back health bars
    public Image frontHealthbar;
    public Image backHealthbar;
    //Variable to save the text of the health
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        //At the start method we match the actual health with the max health
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Clamp the health, it can´t be greater than the max health or less than 0
        health = Mathf.Clamp(health, 0, maxHealth);
        //Update the Health UI every frame
        UpdateHealthUI();

        if(Input.GetKeyDown(KeyCode.T)){
            TakeDamage(Random.Range(5, 10));
        }

        if(Input.GetKeyDown(KeyCode.H)){
            RestoreHealth(Random.Range(5, 10));
        }
    }

    //Function to update the healthbars on the UI
    public void UpdateHealthUI(){
        //Local variable to set the fill quantity of the image on front health bar
        float fillFront = frontHealthbar.fillAmount;
        //Local variable to set the fill quantity of the image on back health bar
        float fillBack = backHealthbar.fillAmount;
        //Variable to make comparations on the UI with values between 0 and 1
        float healthFraction = health / maxHealth;

        //It means we've been taking damage
        if(fillBack > healthFraction){
            //We set the fill amount of the front health bar with the value of the fraction
            //The fill amount value is between 1 and 0, that is why we use this fraction
            frontHealthbar.fillAmount = healthFraction;
            //Set the color red color to the back health bar when we take damage
            backHealthbar.color = Color.red;
            //Start the timer
            lerpTimer = Time.deltaTime;
            //Local variable to calculate the time remaining to update the back health bar
            //We use the variable chip speed to set the update speed
            float percentComplete = lerpTimer / chipSpeed;
            //We make this to square the value and smooth the animation
            //percentComplete = percentComplete * percentComplete;
            //Lerp the back health bar fill amount with the quantity to fill on the back, the health fraction and the percentage of the timer completed
            backHealthbar.fillAmount = Mathf.Lerp(fillBack, healthFraction, percentComplete);
        }

        //It means we've healed
        if(fillFront < healthFraction){
            //Set the color green to the back health bar when we heal
            backHealthbar.color = Color.green;
            //We set the fill amount of the back health bar with the value of the fraction
            //The fill amount value is between 1 and 0, that is why we use this fraction
            backHealthbar.fillAmount = healthFraction;
            //Start the timer
            lerpTimer = Time.deltaTime;
            //Local variable to calculate the time remaining to update the back health bar
            //We use the variable chip speed to set the update speed
            float percentComplete = lerpTimer / chipSpeed;
            //We make this to square the value and smooth the animation
            //percentComplete = percentComplete * percentComplete;
            //Lerp the front health bar fill amount with the quantity to fill on the front, the fill amount on the back health bar
            //and the percentage of the timer completed
            frontHealthbar.fillAmount = Mathf.Lerp(fillFront, backHealthbar.fillAmount, percentComplete);
        }

        //Update the health text
        healthText.text = health + " / " + maxHealth;
    }

    //Function to make the player take damage
    public void TakeDamage(float damage){
        //Substracts damage recieved from health
        health -= damage;
        //Reset the Lerp Timer
        lerpTimer = 0f;
    }

    //Function to restore health of the player
    public void RestoreHealth(float healAmount){
        //Adds the health amount healed to the total health
        health += healAmount;
        //Reset the Lerp Timer
        lerpTimer = 0f;
    }
}
