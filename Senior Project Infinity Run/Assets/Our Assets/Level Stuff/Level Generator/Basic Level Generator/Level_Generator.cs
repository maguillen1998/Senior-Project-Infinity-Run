using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Pair<T1, T2>
{
    public T1 First;
    public T2 Second;
}

public class Level_Generator : MonoBehaviour
{
    public GameObject ReferencePlatfromSquare;
    public GameObject ReferencePlatfromWide;
    public GameObject ReferenceSpike;
    public GameObject ReferenceCoin;

    public GameObject ReferenceSkeleton;
    public GameObject ReferenceGoblin;
    public GameObject ReferenceFlyingEye;
    public GameObject ReferenceMushroom;

    public Camera MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        //testing methods to spawn level terrain
        SpawnPlatformsDemo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPlatformsDemo()
    {
        int levelWidth = 10000;
        float platformWidth = 1f;
        for (int i = 0; i < levelWidth; i++)
        {
            float spawnPosition = transform.position.y;

            float xPosition = transform.position.x + ((float)i * platformWidth) ; //the i value is indicitive of the current x position in the level generation
            float yPosition = (float)spawnPosition;
            float zPosition = transform.position.z; //set to 0 to keep withing the 2d plane of gameplay

            Vector3 position = new Vector3(xPosition, yPosition, zPosition);
            Quaternion rotation = new Quaternion();

            GameObject spawningPlatform = Instantiate(ReferencePlatfromSquare, position, rotation);


            int bufferZone = 20;
            if(i <= bufferZone)
            {
                continue;
            }
            //place skeletons
            int skeletonSeparation = 100;
            int skeletonPlacementChance = 75;
            if(i % skeletonSeparation == 0 && Random.Range(1, 100 + 1) <= skeletonPlacementChance)
            {
                Vector3 skeletonPosition = position;
                Quaternion skeletonRotation = rotation;
                skeletonPosition.y += 1f;
                Instantiate(ReferenceSkeleton, skeletonPosition, skeletonRotation);
            }

            //place coins
            int coinSeparation = 10;
            int coinPlacementChance = 50;
            if (i % coinSeparation == 0 && Random.Range(1,100+1) <= coinPlacementChance)
            {
                Vector3 coinPosition = position;
                Quaternion coinRotation = rotation;
                coinPosition.y += Random.Range(1, 5 + 1);
                Instantiate(ReferenceCoin, coinPosition, coinRotation);
            }

            //place spikes
            int spikeSeparation = 10;
            int spikePlacementChance = 50;
            if (i % spikeSeparation == 0 && Random.Range(1, 100 + 1) <= spikePlacementChance)
            {
                Vector3 spikePosition = position;
                Quaternion spikeRotation = rotation;
                spikePosition.y += Random.Range(1, 5 + 1);
                Instantiate(ReferenceSpike, spikePosition, spikeRotation);
            }
        }
    }

    void SpawnPlatformsNewest()
    {//currently the implementetion is a bit dirty, but it works and is customizable
        float terrainPreviousPlacementHeight = 0f;
        float terrainPlacementHeightVariance = 3f;
        int terrainWidthVariance = 20;
        float terrainCurrentPlacementHeight;//declaring for assignment within the for loop below

        int chasmChance = 25; //%chance to spawn chasm

        int levelChunkLength = 1000;
        Pair<bool, float>[] terrainMap = new Pair<bool, float>[levelChunkLength];//1=terrain placed here 0=empty, float indicates placement height
        int x = 0;
        while (x < levelChunkLength)
        {
            //determine height
            terrainCurrentPlacementHeight = Random.Range(terrainPreviousPlacementHeight - terrainPlacementHeightVariance, terrainPreviousPlacementHeight + terrainPlacementHeightVariance);
            terrainPreviousPlacementHeight = terrainCurrentPlacementHeight;
            int terrainWidth = Random.Range(1, terrainWidthVariance);

            int widthCounter = 0;
            bool shouldPlaceChasm = (Random.Range(1, 100 + 1) <= chasmChance);
            while (x < levelChunkLength && widthCounter < terrainWidth)
            {
                if(shouldPlaceChasm)
                {
                    //do not place anything
                    terrainMap[x].First = false;
                    
                }
                else
                {
                    terrainMap[x].First = true;
                    terrainMap[x].Second = terrainCurrentPlacementHeight;
                }              
                widthCounter++;
                x++;
            }
        }

        for(int i = 0; i < terrainMap.Length; i++)
        {//instantiate platforms based on terrain map
            if(terrainMap[i].First == true)
            {
                Vector3 position = new Vector3(i, Mathf.RoundToInt(terrainMap[i].Second), 0f);
                Quaternion rotation = Quaternion.identity;
                Transform parent = this.gameObject.transform;
                Instantiate(ReferencePlatfromSquare, position, rotation, parent);
            }
            
        }
    }
    void SpawnPlatformsRandom()
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

            GameObject spawningPlatform = Instantiate(ReferencePlatfromSquare, position, rotation);
        }
    }

    void SpawnPlatformsPerlin()
    {
        //testing methods to spawn level terrain
        //Always places form origin. need to allow placement based on local scale and allow the platforms to be spawned anywhere

        //this loop spawns platforms form the ground up to a particular height
        //value determines the length along the x-axis of the terrain generated
        int levelLength = 1000;
        //set to 0 as a baseline starting position
        int previousSpawnHeight = 0; 
        for (int i = 0; i < levelLength; i++)
        {
            float yVariationMultiplier = 5.0f;
            //added +1 to the max random.Range() value because for INT, Random.Range() is inclusive for the min, but exclusive for the max value
            float perlinNoiseZoom = 3f;
            float perlinNoiseVariance = Mathf.PerlinNoise((float)i/perlinNoiseZoom, 0f);
            float adjustedPerlinNoiseVariance = perlinNoiseVariance - 0.5f;//changes range to -0.5 to 0.5
            float finalVarianceAmount = adjustedPerlinNoiseVariance * yVariationMultiplier;
            int spawnHeightPosition = previousSpawnHeight + Mathf.RoundToInt(finalVarianceAmount);
            Debug.Log("FVA: " + finalVarianceAmount);
            //int spawnHeightPosition = Random.Range(previousSpawnHeight - yPlacementVariation, previousSpawnHeight + yPlacementVariation + 1);

            previousSpawnHeight = spawnHeightPosition;

            int chanceChasm = 10;
            if(Random.Range(1,100+1) <= chanceChasm)
            {
                //do nothing for this column
            }
            else
            {
                //places the "floor" of the terrain 10 unitys below the spawn height. this determines the "thickness" of the terrain generated.
                int SpawnFloor = spawnHeightPosition - 15;
                for (int j = SpawnFloor; j < spawnHeightPosition; j++)
                {

                    float xPosition = (float)i; //the i value is indicitive of the current x position in the level generation
                    float yPosition = (float)j;
                    float zPosition = 0f; //set to 0 to keep withing the 2d plane of gameplay

                    Vector3 position = new Vector3(xPosition, yPosition, zPosition);
                    Quaternion rotation = new Quaternion();

                    GameObject spawningPlatform = Instantiate(ReferencePlatfromSquare, position, rotation);
                }
            } 
        }
    }
}
