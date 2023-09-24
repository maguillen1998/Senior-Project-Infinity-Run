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
        SpawnPlatforms();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    void SpawnPlatformsA()
    {
        //Archived
        //This is the first version of the placement algorithm. 
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
    */
    void SpawnPlatforms()
    {
        //testing methods to spawn level terrain
        //Always places form origin. need to allow placement based on local scale and allow the platforms to be spawned anywhere

        //this loop spawns platforms form the ground up to a particular height
        //value determines the length along the x-axis of the terrain generated
        int levelWidth = 1000;
        //set to 0 as a baseline starting position
        int previousSpawnHeight = 0; 
        for (int i = 0; i < levelWidth; i++)
        {
            int yPlacementVariation = 2;
            //added +1 to the max random.Range() value because for INT, Random.Range() is inclusive for the min, but exclusive for the max value
            int spawnHeightPosition = Random.Range(previousSpawnHeight - yPlacementVariation, previousSpawnHeight + yPlacementVariation + 1);
            previousSpawnHeight = spawnHeightPosition;

            //places the "floor" of the terrain 10 unitys below the spawn height. this determines the "thickness" of the terrain generated.
            int SpawnFloor = spawnHeightPosition - 10;
            for(int j = SpawnFloor; j < spawnHeightPosition; j++)
            {
            
                float xPosition = (float)i; //the i value is indicitive of the current x position in the level generation
                float yPosition = (float)j;
                float zPosition = 0f; //set to 0 to keep withing the 2d plane of gameplay

                Vector3 position = new Vector3(xPosition, yPosition, zPosition);
                Quaternion rotation = new Quaternion();

                GameObject spawningPlatform = Instantiate(ReferencePlatform, position, rotation);
            }  
        }
    }
}
