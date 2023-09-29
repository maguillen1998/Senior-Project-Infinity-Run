using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorPlacementReferenceBehaviors : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
