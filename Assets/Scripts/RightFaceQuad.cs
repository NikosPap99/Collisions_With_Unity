using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightFaceQuad : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if(other.name == "CubeSpacebarModel(Clone)" || other.name == "SphereSpacebarModel(Clone)" || other.name == "CylinderSpacebarModel(Clone)") {
            Vector3 newVelocity = other.GetComponent<Rigidbody>().velocity;
            newVelocity[0] = -newVelocity[0];
            other.GetComponent<Rigidbody>().velocity = newVelocity;
        }
    }
}
