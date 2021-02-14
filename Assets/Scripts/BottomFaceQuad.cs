using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is a script for inverting the objects' y-axis velocity once they hit the bottom quad (up and down movement happens on the y axis)
public class BottomFaceQuad : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if(other.name == "CubeSpacebarModel(Clone)" || other.name == "SphereSpacebarModel(Clone)" || other.name == "CylinderSpacebarModel(Clone)") {
            Vector3 newVelocity = other.GetComponent<Rigidbody>().velocity;
            newVelocity[1] = -newVelocity[1];
            other.GetComponent<Rigidbody>().velocity = newVelocity;
        }
    }
}