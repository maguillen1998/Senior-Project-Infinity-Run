using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNewCam : MonoBehaviour
{
    public GameObject TrackedObject;

    int xOffset = 3;
    int yOffset = 3;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(TrackedObject.transform.position.x + xOffset, TrackedObject.transform.position.y + yOffset, -10);
    }

    // Update is called once per frame
    void Update()
    {
        
        this.transform.position = new Vector3(TrackedObject.transform.position.x + xOffset, this.transform.position.y, this.transform.position.z);
        
    }
}
