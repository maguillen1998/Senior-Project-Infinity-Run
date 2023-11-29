using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevelGeneratorScript : MonoBehaviour
{
    public GameObject EasyASegment;
    public GameObject EasyBSegment;
    public GameObject EasyCSegment;
    public GameObject EasyDSegment;

    float LevelSegmentWidth = 10f;
    // Start is called before the first frame update
    void Start()
    {

        GameObject[] EasySegments = new GameObject[4];
        EasySegments[0] = EasyASegment;
        EasySegments[1] = EasyBSegment;
        EasySegments[2] = EasyCSegment;
        EasySegments[3] = EasyDSegment;

        int levelWidth = 100;
        for (int i = 0; i < levelWidth; i++)
        {

            float xPosition = this.transform.position.x + ((float)i * LevelSegmentWidth); //the i value is indicitive of the current x position in the level generation
            float yPosition = this.transform.position.y;
            float zPosition = this.transform.position.z; //set to 0 to keep withing the 2d plane of gameplay

            Vector3 position = new Vector3(xPosition, yPosition, zPosition);
            Quaternion rotation = new Quaternion();


            GameObject chosenSegment = EasySegments[Random.Range(0, 3 + 1)];//cieling is not inclusive.
            GameObject spawningPlatform = Instantiate(chosenSegment, position, rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
