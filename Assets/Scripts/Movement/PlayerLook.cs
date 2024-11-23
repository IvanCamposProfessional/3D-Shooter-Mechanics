using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    //Variable to save and then manipulate the camera
    public Camera cam;
    //Variable to manipulate the X Rotation of the camera
    private float xRotation = 0f;

    //Variable to set the sensitivity to the X axis of the Camera
    private float xSensitivity = 120f;
    //Variable to set the sensitivity to the Y axis of the Camera
    private float ySensitivity = 120f;

    //Define the function that process the look of the Camera getting a Vector2 that is the input of the mouse
    public void ProcessLook(Vector2 input){
        //Save the X and the Y input of the mouse
        float mouseX = input.x;
        float mouseY = input.y;

        //Calculate the Camera Rotation for looking up and down
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        //Calculate the xRotation (value, minimum value we want to be, maximum value we want to be)
        //Clamp restricts a value to a range that is defined by the minimum and maximum values.
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        //Apply this to our camera transform
        //Use a Quaternion.Euler to manage the rotation
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        //Rotate player to look left and right
        //Rotate it with the input of the mouse * the sensitivity
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
