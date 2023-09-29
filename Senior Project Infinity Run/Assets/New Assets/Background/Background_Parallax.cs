using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Parallax : MonoBehaviour
{//this implementation uses hardcoded parallax values to shift each layer. Ideally, we can upgrade the script to allow for dynamic assignment of the parallax value based on either distance from the camera on the z axis, the layers z position, or based on the ground layer z position
    //new vals for different
    private Transform mainCameraTransform;
    private Vector3 lastCameraPosition;
    public float ParallaxFactor = 0;
    // Start is called before the first frame update
    void Start()
    {
        mainCameraTransform = Camera.main.transform;
        lastCameraPosition = mainCameraTransform.position;
    }

    // Update is called once per frame
    void Update()
    {

        BruteForceParallax();
       
    }

    void BruteForceParallax()
    {
        Vector3 cameraMovement = mainCameraTransform.position - lastCameraPosition;
        Vector3 layerPosition = transform.position;

        // Calculate the parallax factor based on the GameObject's z position.
        //float parallaxFactor = transform.position.z + 1; // Adding 1 to avoid division by zero.

        layerPosition.x += cameraMovement.x * ParallaxFactor;
        

        transform.position = layerPosition;
        lastCameraPosition = mainCameraTransform.position;
    }
}
