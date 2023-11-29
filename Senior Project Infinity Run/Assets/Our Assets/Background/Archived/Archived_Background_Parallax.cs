using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archived_Background_Parallax : MonoBehaviour
{
    //needed for new funcs
    Vector3 PreviousCameraPosition;
    Vector3 FarthestLayerPosition;

    //new vals for different
    private Transform mainCameraTransform;
    private Vector3 lastCameraPosition;

    //for brute force method
    public float ParallaxFactor = 0;
    // Start is called before the first frame update
    void Start()
    {
        PreviousCameraPosition = Camera.main.transform.position;
        FarthestLayerPosition = this.gameObject.transform.parent.GetChild(this.gameObject.transform.parent.childCount - 1).transform.position;

        //diff needs
        mainCameraTransform = Camera.main.transform;
        lastCameraPosition = mainCameraTransform.position;
    }

    // Update is called once per frame
    void Update()
    {

        BruteForceParallax();

    }

    //depreciated
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

    //methods below flawed and are not to be used in production
    void NewestParallax()
    {
        //speed needs to increase as it approaches the camera. needs to make the"midpoint" or 0 at the pc ground layer. this should not move.
        //objects farther than the 0 layer need to move slower than the camera the farther they get
        //objects closer than the 0 layer need to move faster than the camera closer they get
        float layerParallaxSpeed = this.gameObject.transform.position.z;

        Camera cam = Camera.main;
        float cameraDisplacement = cam.transform.position.x - PreviousCameraPosition.x;


        this.gameObject.transform.position = this.gameObject.transform.parent.transform.position + new Vector3(1f / cameraDisplacement * layerParallaxSpeed, transform.position.y, transform.position.z);

        Debug.Log(this.gameObject.transform.position.x);

        PreviousCameraPosition = Camera.main.transform.position;

    }
    void NewParallax()
    {
        /*
         move along the x axis based on the maincamera transform. this is multiplied by the layers z position
        slightly follows the camera as it moves up and down
         */
        Camera cam = Camera.main;
        float cameraXDisplacement = cam.transform.position.x - PreviousCameraPosition.x;
        PreviousCameraPosition = Camera.main.transform.position;



        float layerCurrentZ = this.transform.position.z;
        float layerCurrentY = cam.transform.position.y / 100;
        float layerMultiplier = (layerCurrentZ) / this.gameObject.transform.parent.GetChild(this.gameObject.transform.parent.transform.childCount - 1).transform.position.z;
        float parallaxSpeedModifier = this.gameObject.GetComponentInParent<Background_Extender>().ParallaxFactor;//getting from parent script
        float layerNewX = cameraXDisplacement * layerMultiplier * parallaxSpeedModifier;//not sure why the - is neccessary atm
        Vector3 newLayerPosition = new Vector3(layerNewX, layerCurrentY, layerCurrentZ);
        this.gameObject.transform.position = this.gameObject.transform.parent.transform.position + newLayerPosition;
    }
    void OldParallax()
    {
        /*
         move along the x axis based on the maincamera transform. this is multiplied by the layers z position
         */
        Camera cam = Camera.main;

        float layerCurrentZ = this.transform.position.z;
        float layerCurrentY = this.transform.position.y;
        float layerMultiplier = 1 / layerCurrentZ;
        float parallaxSpeedModifier = this.gameObject.GetComponentInParent<Background_Extender>().ParallaxFactor;//getting from parent script
        float layerNewX = -1 * cam.transform.position.x * layerMultiplier * parallaxSpeedModifier;//not sure why the - is neccessary atm
        Vector3 newLayerPosition = new Vector3(layerNewX, layerCurrentY, layerCurrentZ);

        this.gameObject.transform.position = this.gameObject.transform.parent.transform.position + newLayerPosition;
    }
}
