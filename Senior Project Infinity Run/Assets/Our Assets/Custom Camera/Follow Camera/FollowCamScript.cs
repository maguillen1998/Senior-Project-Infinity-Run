using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamScript : MonoBehaviour
{
    public GameObject Target;
    public Vector3 Boundries = new Vector3(5f,1f,-10f);//may want to refactor and remove assignment of z pos from this variable. z should always be -10 to avoid clipping
    public float CameraMovementSpeedMultiplier = 1f;
    public Vector2 TargetOffsets = new Vector2(0f,0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        if(Target != null)
        {
            OffsetAdjustCamera();
        }
        else
        {
            Debug.LogError("!!!FollowCam Target Unassigned!!!");
        }
        
    }
    void OffsetAdjustCamera()
    {
        float leadAmountX = Boundries.x;
        float leadAmountY = Boundries.y;

        Vector3 direction = Target.GetComponent<Rigidbody2D>().velocity.normalized;
        direction.z = Boundries.z;
        Vector3 desiredPosition = new Vector3((Target.transform.position.x + direction.x * leadAmountX)+TargetOffsets.x, (Target.transform.position.y + direction.y * leadAmountY) + TargetOffsets.y , Boundries.z);

        MoveCameraSmoothlyTo(desiredPosition);
    }

    void AdjustCamera()
    {
        float leadAmountX = Boundries.x;
        float leadAmountY = Boundries.y;

        Vector3 direction = Target.GetComponent<Rigidbody2D>().velocity.normalized;
        direction.z = Boundries.z;
        Vector3 desiredPosition = new Vector3(Target.transform.position.x + direction.x * leadAmountX, Target.transform.position.y + direction.y * leadAmountY, Boundries.z);

        MoveCameraSmoothlyTo(desiredPosition);
    }
    void MoveCameraSmoothlyTo(Vector3 desiredPosition)
    {
        //setting speed based on 
        float AjustedSmoothSpeedX = (Mathf.Abs(Target.GetComponent<Rigidbody2D>().velocity.x) * CameraMovementSpeedMultiplier) * Time.deltaTime; //based on targer  rigidbody x speed
        float AjustedSmoothSpeedY = (Mathf.Abs(Target.GetComponent<Rigidbody2D>().velocity.y) * CameraMovementSpeedMultiplier) * Time.deltaTime; //based on targer  rigidbody y speed

        Vector3 interpolatedX = Vector3.Lerp(transform.position, desiredPosition, AjustedSmoothSpeedX);//interpolate based on x speed
        Vector3 interpolatedY = Vector3.Lerp(transform.position, desiredPosition, AjustedSmoothSpeedY);//interpolate based on y speed

        //combine x and y from each vector3 to get both x and y combined smoothedposition
        Vector3 smoothedPosition = new Vector3(interpolatedX.x, interpolatedY.y, transform.position.z);//keep Z position the same

        smoothedPosition.z = Boundries.z;
        transform.position = smoothedPosition;
    }
}
