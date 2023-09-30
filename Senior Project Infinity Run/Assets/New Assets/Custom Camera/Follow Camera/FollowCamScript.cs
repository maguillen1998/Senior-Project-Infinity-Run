using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamScript : MonoBehaviour
{
    public GameObject Target;
    public float SmoothSpeed = 0.125f;
    public Vector3 Offset = new Vector3(0f,0f,-10f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        if(Target != null)
        {

            temp();
        }
        else
        {
            Debug.LogError("!!!FollowCam Target Unassigned!!!");
        }
        
    }

    void temp()
    {
        float leadAmountX = Offset.x;
        float leadAmountY = Offset.y;

        Vector3 direction = Target.GetComponent<Rigidbody2D>().velocity.normalized;
        direction.z = Offset.z;
        Vector3 desiredPosition = new Vector3(Target.transform.position.x + direction.x * leadAmountX, Target.transform.position.y + leadAmountY, Offset.z);

        MoveCameraSmoothlyTo(desiredPosition);
    }
    void MoveCameraSmoothlyTo(Vector3 desiredPosition)
    {
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);

        smoothedPosition.z = Offset.z;
        transform.position = smoothedPosition;
    }
}
