using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevelGeneratorScript : MonoBehaviour
{
    public GameObject EmptySegment;

    public GameObject EasyASegment;
    public GameObject EasyBSegment;
    public GameObject EasyCSegment;
    public GameObject EasyDSegment;

    public GameObject MediumASegment;
    public GameObject MediumBSegment;
    public GameObject MediumCSegment;
    public GameObject MediumDSegment;

    public GameObject HardASegment;
    public GameObject HardBSegment;
    public GameObject HardCSegment;
    public GameObject HardDSegment;

    float LevelSegmentWidth = 10f;
    public int NumEmptySegments = 3; //amount of empty segments that will be placed at the start
    // Start is called before the first frame update
    void Start()
    {

        GameObject[] EasySegments = new GameObject[4];
        EasySegments[0] = EasyASegment;
        EasySegments[1] = EasyBSegment;
        EasySegments[2] = EasyCSegment;
        EasySegments[3] = EasyDSegment;

        GameObject[] MediumSegments = new GameObject[4];
        MediumSegments[0] = MediumASegment;
        MediumSegments[1] = MediumBSegment;
        MediumSegments[2] = MediumCSegment;
        MediumSegments[3] = MediumDSegment;

        GameObject[] HardSegments = new GameObject[4];
        HardSegments[0] = HardASegment;
        HardSegments[1] = HardBSegment;
        HardSegments[2] = HardCSegment;
        HardSegments[3] = HardDSegment;

        int levelWidth = 100;
        for (int i = 0; i < levelWidth; i++)
        {

            float xPosition = this.transform.position.x + ((float)i * LevelSegmentWidth); //the i value is indicitive of the current x position in the level generation
            float yPosition = this.transform.position.y;
            float zPosition = this.transform.position.z; //set to 0 to keep withing the 2d plane of gameplay

            Vector3 position = new Vector3(xPosition, yPosition, zPosition);
            Quaternion rotation = new Quaternion();

            GameObject chosenSegment;

            
            if (i <= NumEmptySegments)
            {
                chosenSegment = EmptySegment;
            }
            else if(i <= 0)
            {
                chosenSegment = EasySegments[Random.Range(0, 3 + 1)];//cieling is not inclusive.
            }
            else if (i <= 1000)
            {
                chosenSegment = MediumSegments[Random.Range(0, 3 + 1)];//cieling is not inclusive.
                //chosenSegment = MediumSegments[0];//cieling is not inclusive.
            }
            else
            {
                chosenSegment = HardSegments[Random.Range(0, 3 + 1)];//cieling is not inclusive.
            }

            GameObject spawningPlatform = Instantiate(chosenSegment, position, rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
