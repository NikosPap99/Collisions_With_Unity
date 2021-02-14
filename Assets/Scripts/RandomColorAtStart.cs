using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for assigning a random color at start for the main cube
// the change is done in the start function, because we want to change color at the first frame
[RequireComponent(typeof(Renderer))]
public class RandomColorAtStart : MonoBehaviour
{

    void Start()
    {
        Color randomColor = new Color(
            Random.Range(0f, 1f), //R
            Random.Range(0f, 1f), //G
            Random.Range(0f, 1f), //B
            0.5f  //Alpha (transparency)          
        );
        
        GetComponent<Renderer>().material.color = randomColor; // assignign the color to the cube material
        
    }
}
