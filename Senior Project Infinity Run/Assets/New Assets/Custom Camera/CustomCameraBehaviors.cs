using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCameraBehaviors : MonoBehaviour
{
    //set to null to allow checking if the player has not been found. 
    GameObject player = null;

    //Important to offset on the Z axis to avoid accidentally clipping the PC, causing their sprite to disappear due to it being too close to the camera
    //z offset must be > the  close clipping plane of the camera
    Vector3 offset = new Vector3(0,0,-10);
    // Start is called before the first frame update
    void Start()
    {
        //if checks to make sure that the "Player Character" tag exists before trying to access it to assign to the player variable
        if(GameObject.FindWithTag("Player Character"))
        {
            player = GameObject.FindWithTag("Player Character");
            Debug.Log("Camera: script SUCCESSFULLY found GameObject tagged 'Player Character'");
        }
        else
        {
            Debug.Log("Camera: script FAILED to find GameObject tagged 'Player Character'");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            //set the camera position to the player position offset by the offset value
            transform.position = player.transform.position + offset;
        }
        else
        {
            Debug.Log("Camera: Player not found, cannot update camera position");
            //may be viable to attempt to find GameObject with "player Charcter" tag
        }
    }
}
