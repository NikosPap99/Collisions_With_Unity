using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
using System.IO; 

public class MainSphereEnablingTexture : MonoBehaviour
{
    public Material[] materials; // this is assigned to a collection of 2 materials, one for the red color, and the other for the texture
    Renderer renderer;
    
    void Start() { 
        renderer = GetComponent<Renderer>();
        renderer.sharedMaterial = materials[0]; // the first material is assigned to the bright red color material
        // loading the texture to the material
        Texture2D texture = new Texture2D(2, 2);
        byte[] fileData = File.ReadAllBytes("texture-sphere.jpg");
        texture.LoadImage(fileData);
        materials[1].SetTexture("_MainTex", texture);
    }

    
    void Update() {
        // Change the materials order when we press "t". The sphere will use the first material in the collection.
        // In that way, we can change between red color and texture material.
        if(Input.GetKeyUp ("t")) {
            Material previousTop = materials[0];
            materials[0] = materials[1];
            materials[1] = previousTop;
            renderer.sharedMaterial = materials[0];
        }
    }
}
