using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Parallax : MonoBehaviour
{
    private Transform mainCameraTransform;
    private Vector3 lastCameraPosition;
    private float FarthestZPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        FarthestZPosition = transform.parent.GetChild(transform.parent.childCount - 1).transform.position.z;//the last child should have the highest Z value
        mainCameraTransform = Camera.main.transform;
        lastCameraPosition = mainCameraTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        DynamicZParallax();
    }

    void DynamicZParallax()
    {
        Vector3 cameraMovement = mainCameraTransform.position - lastCameraPosition;
        Vector3 layerPosition = transform.position;

        float ParallaxFactor = transform.position.z / FarthestZPosition;

        layerPosition.x += cameraMovement.x * ParallaxFactor;

        transform.position = layerPosition;
        lastCameraPosition = mainCameraTransform.position;
    }
  
}
