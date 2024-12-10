using UnityEngine;

public class Gun : MonoBehaviour
{
    //The quantity of damage the gun does
    public float damage = 10f;
    //The distance the gun arrives
    public float range = 100f;

    //Variable for saving the PlayerInput
    //private PlayerInput playerInput;
    //Variable for saving the Action OnFoot on PlayerInput
    //public PlayerInput.OnFootActions onFoot;

    /*void Awake()
    {   
        //Initialize both variables
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        onFoot.Shoot.performed += ctx => Debug.Log("Shoot");
    }*/

    // Update is called once per frame
    void Update()
    {
        //If the Player left clicks
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    private void Shoot(){
        
    }
}
