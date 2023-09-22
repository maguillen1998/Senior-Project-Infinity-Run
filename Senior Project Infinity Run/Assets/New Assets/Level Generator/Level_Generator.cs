using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Generator : MonoBehaviour
{
    public GameObject ReferencePlatform;
    public Camera MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        //testing methods to spawn level terrain
        //spawns platforms within a set distance of eachother in height.
        int levelWidth = 1000;
        for (int i = 0; i < levelWidth; i++)
        {
            int yPlacementVariation = 4;
            int spawnPosition = Random.Range(5 - yPlacementVariation, 5 + yPlacementVariation);

            float xPosition = (float)i; //the i value is indicitive of the current x position in the level generation
            float yPosition = (float)spawnPosition; 
            float zPosition = 0f; //set to 0 to keep withing the 2d plane of gameplay

            Vector3 position = new Vector3(xPosition, yPosition, zPosition);
            Quaternion rotation = new Quaternion();

            GameObject spawningPlatform = Instantiate(ReferencePlatform, position, rotation);
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
