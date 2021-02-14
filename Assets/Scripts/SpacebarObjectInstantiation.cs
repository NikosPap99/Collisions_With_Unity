using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacebarObjectInstantiation : MonoBehaviour
{
    private float objectsSpeed; // a value which is used to multiply the objects' starting velocity
    public GameObject SphereSpacebarModel; // these models will be used for object instantiation
    public GameObject CylinderSpacebarModel;
    public GameObject CubeSpacebarModel;
    private List<GameObject> spacebarModels; // contains the 3 models (cube, sphere, cylinder)
    private List<GameObject> spacebarObjects = new List<GameObject>(); // contains all the objects I have instantiated
    private List<float> spacebarObjectsDimensions = new List<float>(); // contains the dimensions of each object
    private static System.Random rnd = new System.Random(); // for random dimensions/velocity generation

    void Start() {
        objectsSpeed = 100.0f;           
        spacebarModels = new List<GameObject> { SphereSpacebarModel, CylinderSpacebarModel, CubeSpacebarModel}; 
    }


    void Update()
    {
        if(Input.GetKeyDown("space")) {
            float minDimension = 0.01f;
            int sizeScaleFactor = rnd.Next(1, 10);
            int objectChoice = rnd.Next(0, 3); // random int between 0, 1, 2 for object choice
            float max = 0.9f;
            float min = 0.1f;
            float objectVelocityX = (float)(rnd.NextDouble() * (max - min) + min); // velocitites in range [0.1, 0.9]
            float objectVelocityY = (float)(rnd.NextDouble() * (max - min) + min);
            float objectVelocityZ = (float)(rnd.NextDouble() * (max - min) + min);
            float newDimension = minDimension * sizeScaleFactor; // gives object dimension in [0.1, 0.2, ..., 0.9]
            GameObject newObject = Instantiate(spacebarModels[objectChoice], new Vector3(newDimension/2, newDimension/2, newDimension/2), Quaternion.identity);
            Vector3 loc = newObject.transform.localScale; // localscale used for scaling once the object has been instantiated
            loc.x = sizeScaleFactor * loc.x;
            loc.y = sizeScaleFactor * loc.y;
            loc.z = sizeScaleFactor * loc.z;
            newObject.transform.localScale = loc;
            MeshRenderer renderer = newObject.GetComponent<MeshRenderer>();
            renderer.enabled = true; // render the objects (the original ones are not rendered, because we don't want them to be visible)
            Color randomColor = new Color(
                Random.Range(0f, 1f), //R
                Random.Range(0f, 1f), //G
                Random.Range(0f, 1f), //B  
                1.0f  //Alpha (transparency)      
            );
        
            newObject.GetComponent<Renderer>().material.color = randomColor; // setting the random color
            // giving the random initial velocity using frame logic
            newObject.GetComponent<Rigidbody>().velocity = new Vector3(objectsSpeed * objectVelocityX * Time.deltaTime, objectsSpeed * objectVelocityY * Time.deltaTime, Time.deltaTime * objectsSpeed * objectVelocityZ);
            spacebarObjects.Add(newObject); // adding the object to the list
            spacebarObjectsDimensions.Add(newDimension); // addint the object dimension to the list
        }

        // if ">" is pressed, the objects that have already been instantiated speed up
        if(Input.GetKey("left shift")) {
            if(Input.GetKey(".")) { 
                for(int i = 0; i < spacebarObjects.Count; i++) {
                    Vector3 velo = spacebarObjects[i].GetComponent<Rigidbody>().velocity; 
                    velo.x *= 1.003f;
                    velo.y *= 1.003f;
                    velo.z *= 1.003f;
                    spacebarObjects[i].GetComponent<Rigidbody>().velocity = velo;
                }
            }

            // if "<" is pressed, the objects that have already been instantiated slow down
            if(Input.GetKey(",")) {
                for(int i = 0; i < spacebarObjects.Count; i++) {
                    Vector3 velo = spacebarObjects[i].GetComponent<Rigidbody>().velocity;
                    velo.x /= 1.003f;
                    velo.y /= 1.003f;
                    velo.z /= 1.003f;
                    spacebarObjects[i].GetComponent<Rigidbody>().velocity = velo;
                }
            }
        }

        // this for loop checks if any object has exceeded the cube limits and puts it back inside if that's the case
        // this is needed because otherwise I noticed objects exceeding the limits after collisions with other objects/the player capsule
        for(int i = 0; i < spacebarObjects.Count; i++) {
            float upperLimit = 1 - spacebarObjectsDimensions[i]/2; // position upper limit
            float lowerLimit = 0 + spacebarObjectsDimensions[i]/2; // position lower limit

            if(spacebarObjects[i].transform.position.x > upperLimit) {
                spacebarObjects[i].transform.position = new Vector3(upperLimit, spacebarObjects[i].transform.position.y, spacebarObjects[i].transform.position.z);
            }

            if(spacebarObjects[i].transform.position.x < lowerLimit) {
                spacebarObjects[i].transform.position = new Vector3(lowerLimit, spacebarObjects[i].transform.position.y, spacebarObjects[i].transform.position.z);
            }

            if(spacebarObjects[i].transform.position.y > upperLimit) {
                spacebarObjects[i].transform.position = new Vector3(spacebarObjects[i].transform.position.x, upperLimit,  spacebarObjects[i].transform.position.z);
            }

            if(spacebarObjects[i].transform.position.y < lowerLimit) {
                spacebarObjects[i].transform.position = new Vector3(spacebarObjects[i].transform.position.x, lowerLimit,  spacebarObjects[i].transform.position.z);
            }

            if(spacebarObjects[i].transform.position.z > upperLimit) {
                spacebarObjects[i].transform.position = new Vector3(spacebarObjects[i].transform.position.x, spacebarObjects[i].transform.position.y, upperLimit);
            }

            if(spacebarObjects[i].transform.position.z < lowerLimit) {
                spacebarObjects[i].transform.position = new Vector3(spacebarObjects[i].transform.position.x, spacebarObjects[i].transform.position.y, lowerLimit);
            }
        }
        
    }
}
