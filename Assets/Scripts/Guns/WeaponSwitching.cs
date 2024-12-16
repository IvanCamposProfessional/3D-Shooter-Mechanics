using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    //Variable to know which weapon we selected
    public int selectedWeapon = 0;

    // Start is called before the first frame update
    void Start()
    {
        //At the start of the game we select the current weapon
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        //Temporal variable to save the previous selected weapon
        //We define it before it gets changed on the frame
        int previousSelectedWeapon = selectedWeapon;

        //If the player scrolls up the mouse scroll wheel
        //It works when its scrolled up because GetAxis("Mouse ScrollWheel") is a float that if it's greater than 0 it means it's been scrolled up
        if(Input.GetAxis("Mouse ScrollWheel") > 0f){
            //If the selected weapon is equal or greater to the number of weapons we have
            if(selectedWeapon >= transform.childCount - 1){
                //Set the selected weapon to the first one
                selectedWeapon = 0;
            //If not
            }else{
                //Change the selected weapon to 1 more
                selectedWeapon++;
            }
        }

        //If the player scrolls down the mouse scroll wheel
        //It works when its scrolled up because GetAxis("Mouse ScrollWheel") is a float that if it's less than 0 it means it's been scrolled down
        if(Input.GetAxis("Mouse ScrollWheel") < 0f){
            //If the selected weapon is equal or less to 0
            if(selectedWeapon <= 0){
                //Set the selected weapon to the last one
                selectedWeapon = transform.childCount - 1;
            //If not
            }else{
                //Change the selected weapon to 1 less
                selectedWeapon--;
            }
        }

        //If the weapon has changed on this frame
        if(previousSelectedWeapon != selectedWeapon){
            //Change the weapon
            SelectWeapon();
        }
    }

    //Function to define and select a weapon
    void SelectWeapon(){
        //Variable to know on wich iteration of the loop we are
        int i = 0;
        //For each transform on the Game Object
        foreach(Transform weapon in transform){
            //If the iteration is the same than the selected weapon
            if(i == selectedWeapon){
                //We set active the corresponding weapon
                weapon.gameObject.SetActive(true);
            //If the index doesn't match with the selected weapon 
            }else{
                //We set the weapon corresponding to the iteration to false
                weapon.gameObject.SetActive(false);
            }

            i++;
        }
    }
}
