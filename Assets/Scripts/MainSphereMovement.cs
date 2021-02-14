using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSphereMovement : MonoBehaviour
{
    public float sphereRadius; // the sphere radius is needed for limiting the sphere movement to inside the cube 
    SphereCollider collider;

    void Start()
    {
        //Assigns the attached SphereCollider to collider
        collider = GetComponent<SphereCollider>();
        sphereRadius = collider.radius;
    }

    
    void Update()
    {
        float sphereSpeed = 4f; // a speed value for the movement
        // these are initiated at 0 in each frame, because if we don't do that then the sphere will move faster each frame it moves to the same direction
        float xMovement = 0.0f;
        float yMovement = 0.0f;
        float zMovement = 0.0f;

        // right keyboard arrow
        if(Input.GetKey("right")) {
            xMovement += 0.1f;
        }

        // left keyboard arrow
        if(Input.GetKey("left")) {
            xMovement -= 0.1f;
        }

        // up keyboard arrow
        if(Input.GetKey("up")) {
            yMovement += 0.1f;
        }

        // down keyboard arrow
        if(Input.GetKey("down")) {
            yMovement -= 0.1f;
        }

        // + keyboard button
        if(Input.GetKey("left shift")) {
            if(Input.GetKey(KeyCode.Equals)) {
                zMovement += 0.1f;
            }
        }

        // - keyboard button
        if(Input.GetKey(KeyCode.Minus)) {
            zMovement -= 0.1f;
        }
        
        // I use translation in order to move the sphere around. I limit its movement to inside the cube with the Mathf.Clamp function
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp (pos.x, 0 + sphereRadius/2, 1 - sphereRadius/2);
        pos.y = Mathf.Clamp (pos.y, 0 + sphereRadius/2, 1 - sphereRadius/2);
        pos.z = Mathf.Clamp (pos.z, 0 + sphereRadius/2, 1 - sphereRadius/2);
        transform.position = pos;
        transform.Translate(sphereSpeed * xMovement * Time.deltaTime, sphereSpeed * yMovement * Time.deltaTime, sphereSpeed * zMovement * Time.deltaTime);
        
    }
}
