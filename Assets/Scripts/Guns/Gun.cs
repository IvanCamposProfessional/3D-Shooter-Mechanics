using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    Transform gunAim;
    //Variable to save the line renderer
    [SerializeField]
    LineRenderer lineRend;

    //The quantity of damage the gun does
    public float damage = 10f;
    //The distance the gun arrives
    public float range = 100f;
    //The fire rate of the gun
    public float fireRate = 15f;
    //Variable to save the camera
    public Camera fpsCam;

    //Variable to count the time between shots
    private float nextTimeToFire = 0f;

    // Update is called once per frame
    void Update()
    {
        //If the Player left clicks and the time is = to the next Time to Fire
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire){
            //Each frame we increment 0.6 the time to fire
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    private void Shoot(){
        //Variable to save the hit info of the raycast
        RaycastHit hit;
        //Create a raycast from the camera when we shoot
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
            //Enable the line renderer
            lineRend.enabled = true;
            //Set the position of the line renderer
            lineRend.SetPosition(0, gunAim.transform.position);
            lineRend.SetPosition(1, hit.point);
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if(enemy != null){
                hit.transform.GetComponent<Enemy>().TakeDamage(damage);
                Debug.Log(enemy.health);
                //Debug.Log(hit.transform.name);
            }
        }
    }
}
