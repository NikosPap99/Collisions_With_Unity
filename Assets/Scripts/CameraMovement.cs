using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player; // a capsule game object in which I have installed the camera

    // Update is called once per frame
    void Update()
    {
        float mouseSensitivity = 100f; 
        float movementSpeed = 6f;
        float yMovement = 0;

        if(Input.GetKey ("e")) {
            yMovement += 1f;
        }

        if(Input.GetKey ("x")) {
            yMovement -= 1f;
        }

        // the rotations around the x and y axis are done seperately, because when they are done on the same object, there is a weird camera tilt
        transform.Rotate(-Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity, 0, 0); // rotate the camera around the x-axis when mouse is moving on y-axis
        player.transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity, 0); // rotate the player around the y-axis when mouse is moving on x-axis
        player.transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed, yMovement * Time.deltaTime * movementSpeed, Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed);
        // move the player 
    }
}
