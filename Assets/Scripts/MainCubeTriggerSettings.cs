using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is a script used for inverting the cube normals once the player has entered it.
// This needs to be done because unity by default doesn't show the insides of objects for performance reasons.
public class MainCubeTriggerSettings : MonoBehaviour
{
    public GameObject cube;

    void OnTriggerEnter(Collider other) {
        if(other.name == "Player") { // player is the name of the player capsule
            InvertCubeNormals();
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.name == "Player") {
            InvertCubeNormals();
        }
    }

    // the function which inverts the cube normals
    void InvertCubeNormals() {
        Vector3[] normals = cube.GetComponent<MeshFilter>().mesh.normals;

        for(int i = 0; i < normals.Length; i++)
        {
            normals[i] = -normals[i];
        }

        cube.GetComponent<MeshFilter>().mesh.normals = normals;

        int[] triangles = cube.GetComponent<MeshFilter>().mesh.triangles;

        for (int i = 0; i < triangles.Length; i+=3)
        {
            int t = triangles[i];
            triangles[i] = triangles[i + 2];
            triangles[i + 2] = t;
        }           

        cube.GetComponent<MeshFilter>().mesh.triangles= triangles;
    }
}