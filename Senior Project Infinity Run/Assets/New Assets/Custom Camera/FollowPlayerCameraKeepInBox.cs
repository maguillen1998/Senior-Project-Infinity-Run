using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCameraKeepInBox : MonoBehaviour
{
    //set to null to allow checking if the player has not been found. 
    GameObject Player = null;
    

    //Important to offset on the Z axis to avoid accidentally clipping the PC, causing their sprite to disappear due to it being too close to the camera
    //z offset must be > the  close clipping plane of the camera
    Vector3 Offset;
    float XOffset = 0f;
    float YOffset = 0f;
    public float ZOffset = -10f;

    //rate per fixed update at which the camera is moved into the correct position. may bug out is set very high >1,000. likely to do with the fix for 1 boundry causing the camera to move out of bounds of another boundry
    public float AdjustmentSpeed = 1f;

    //positional boundrys for the player !!!must ensure these are not set to overlap or the camera with bug out!!!
    public float RightBoundry = 3f;
    public float LeftBoundry = -3f;
    public float TopBoundry = 3f;
    public float BottomBoundry = -3f;

    bool PlayerOutOfBoundsRight = false;
    bool PlayerOutOfBoundsLeft = false;
    bool PlayerOutOfBoundsTop = false;
    bool PlayerOutOfBoundsBottom = false;
    // Start is called before the first frame update
    void Start()
    {
        //float camHeight = this.GetComponent<Camera>().orthographicSize * 2f;
        UpdateCameraOffset();
        //if checks to make sure that the "Player Character" tag exists before trying to access it to assign to the player variable
        if (GameObject.FindWithTag("Player Character"))
        {
            Player = GameObject.FindWithTag("Player Character");
            ApplyPlayerTransformToCameraWithOffset();
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
        if (Player != null)
        {
            //set the camera position to the player position offset by the offset value
            UpdateCameraOffset();//update to reflect editor changes to variable
            //ApplyPlayerTransformToCameraWithOffset();
            SetAdjustmentBools();
            ApplyAdjustments();

        }
        else
        {
            Debug.Log("Camera: Player not found, cannot update camera position");
            //may be viable to attempt to find GameObject with "player Charcter" tag
        }
    }

    void ApplyAdjustments()
    {
        if (PlayerOutOfBoundsRight)
        {
            //adjust camera to the right
            //set adjustment offset
            //Vector3 adjustmentOffset = new Vector3(AdjustmentSpeed * Time.deltaTime, 0, 0);

            transform.position = new Vector3(Player.transform.position.x - RightBoundry, transform.position.y, transform.position.z);

        }
        if (PlayerOutOfBoundsLeft)
        {
            //adjust camera to the left
            //Vector3 adjustmentOffset = new Vector3(-AdjustmentSpeed * Time.deltaTime, 0, 0);
            //transform.position += adjustmentOffset;

            transform.position = new Vector3(Player.transform.position.x - LeftBoundry, transform.position.y, transform.position.z);
        }
        if (PlayerOutOfBoundsTop)
        {
            //adjust camera to the top
            //Vector3 adjustmentOffset = new Vector3(0, AdjustmentSpeed * Time.deltaTime, 0);
            //transform.position += adjustmentOffset;
            transform.position = new Vector3(transform.position.x, Player.transform.position.y - TopBoundry, transform.position.z);
        }
        if (PlayerOutOfBoundsBottom)
        {
            //adjust camera to the bottom
            //Vector3 adjustmentOffset = new Vector3(0, -AdjustmentSpeed * Time.deltaTime, 0);
            //transform.position += adjustmentOffset;

            transform.position = new Vector3(transform.position.x, Player.transform.position.y - BottomBoundry, transform.position.z);
        }


    }
    void SetAdjustmentBools()
    {
        //check if player is past right Boundry
        PlayerOutOfBoundsRight = false;
        //if player position relative to camera is past right boundry
        Vector3 playerPositionRelativeToCamera = Player.transform.position - gameObject.transform.position;//relative pos = player position - camera position
        if (playerPositionRelativeToCamera.x > RightBoundry)
        {
            PlayerOutOfBoundsRight = true;
        }

        //check if player is past left Boundry
        PlayerOutOfBoundsLeft = false;
        if (playerPositionRelativeToCamera.x < LeftBoundry)
        {
            PlayerOutOfBoundsLeft = true;
        }

        //check if player is past top Boundry
        PlayerOutOfBoundsTop = false;
        if (playerPositionRelativeToCamera.y > TopBoundry)
        {
            PlayerOutOfBoundsTop = true;
        }

        //check if player is past bottom Boundry
        PlayerOutOfBoundsBottom = false;
        if (playerPositionRelativeToCamera.y < BottomBoundry)
        {
            PlayerOutOfBoundsBottom = true;
        }
    }

    void UpdateCameraOffset()
    {
        Offset = new Vector3(XOffset, YOffset, ZOffset);
    }

    void ApplyPlayerTransformToCameraWithOffset()
    {
        transform.position = Player.transform.position + Offset;
    }
}
