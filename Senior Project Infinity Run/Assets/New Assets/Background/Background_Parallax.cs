using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Parallax : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
         move along the x axis based on the maincamera transform. this is multiplied by the layers z position
         */
        Camera cam = Camera.main;

        float layerCurrentZ = this.transform.position.z;
        float layerCurrentY = this.transform.position.y;
        float layerMultiplier = 1/layerCurrentZ;
        float parallaxSpeedModifier = this.gameObject.GetComponentInParent<Background_Extender>().ParallaxFactor;//getting from parent script
        float layerNewX = -cam.transform.position.x * layerMultiplier * parallaxSpeedModifier;//not sure why the - is neccessary atm
        Vector3 newLayerPosition = new Vector3(layerNewX, layerCurrentY, layerCurrentZ);

        this.gameObject.transform.position = this.gameObject.transform.parent.transform.position + newLayerPosition;
    }
}
