using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing_dummy_behavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHit()
    {
        Debug.Log(gameObject.name + "was Hit");
    }
}
