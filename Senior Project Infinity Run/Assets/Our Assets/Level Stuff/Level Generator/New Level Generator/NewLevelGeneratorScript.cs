using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevelGeneratorScript : MonoBehaviour
{
    public GameObject PC;

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


    GameObject[] EasySegments;
    GameObject[] MediumSegments;
    GameObject[] HardSegments;

    GameObject[] SegmentPool;//coul be useful for making version where harder segments get added to placement pool and any difficulty unlocked can be placed.

    float LevelSegmentWidth = 10f;//width of each segment in units
    public int NumEmptySegments = 3; //amount of empty segments that will be placed at the start
    // Start is called before the first frame update

    //LinkedList<GameObject> CurrentSegments;
    List<GameObject> CurrentSegments;

    void Start()
    {
        //initailize segment arrays
        EasySegments = new GameObject[4];
        EasySegments[0] = EasyASegment;
        EasySegments[1] = EasyBSegment;
        EasySegments[2] = EasyCSegment;
        EasySegments[3] = EasyDSegment;

        MediumSegments = new GameObject[4];
        MediumSegments[0] = MediumASegment;
        MediumSegments[1] = MediumBSegment;
        MediumSegments[2] = MediumCSegment;
        MediumSegments[3] = MediumDSegment;

        HardSegments = new GameObject[4];
        HardSegments[0] = HardASegment;
        HardSegments[1] = HardBSegment;
        HardSegments[2] = HardCSegment;
        HardSegments[3] = HardDSegment;

        //place a starter segment
        float xPosition = this.transform.position.x; //the i value is indicitive of the current x position in the level generation
        float yPosition = this.transform.position.y;
        float zPosition = this.transform.position.z; //set to 0 to keep withing the 2d plane of gameplay

        Vector3 position = new Vector3(xPosition, yPosition, zPosition);
        Quaternion rotation = new Quaternion();

        GameObject chosenSegment;

        chosenSegment = EmptySegment;
        
        GameObject spawningPlatform = Instantiate(chosenSegment, position, rotation, this.transform);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //check if last segment is too close, if so, instantiate a new segment ahead of the player
        GameObject lastSegment;
        float lastSegmentDistance;
        
        lastSegment = this.transform.GetChild(this.transform.childCount - 1).gameObject;
        lastSegmentDistance = lastSegment.transform.position.x - PC.transform.position.x;                
        
        if (lastSegmentDistance <= 20f)
        {
            float xPosition = (lastSegment.transform.position.x + LevelSegmentWidth); //the i value is indicitive of the current x position in the level generation
            float yPosition = this.transform.position.y;
            float zPosition = this.transform.position.z; //set to 0 to keep withing the 2d plane of gameplay

            Vector3 position = new Vector3(xPosition, yPosition, zPosition);
            Quaternion rotation = new Quaternion();

            GameObject chosenSegment;

            //this version places only from a given category at a time.
            if (Time.timeSinceLevelLoad <= 1)
            {
                chosenSegment = EmptySegment;
            }
            else if (Time.timeSinceLevelLoad <= 20)
            {
                chosenSegment = EasySegments[Random.Range(0, 3 + 1)];//cieling is not inclusive.
            }
            else if (Time.timeSinceLevelLoad <= 40)
            {
                chosenSegment = MediumSegments[Random.Range(0, 3 + 1)];//cieling is not inclusive.               
            }
            else
            {
                chosenSegment = HardSegments[Random.Range(0, 3 + 1)];//cieling is not inclusive.               
            }

            GameObject spawningPlatform = Instantiate(chosenSegment, position, rotation, this.transform);
        }

        //check if first segment is too far behind the player, if so, destroy it.
        GameObject firstSegment = this.transform.GetChild(0).gameObject;
        float firstSegmentDistance = firstSegment.transform.position.x - PC.transform.position.x;

        if(Mathf.Abs(firstSegmentDistance) >= 20f + LevelSegmentWidth)
        {            
            Destroy(firstSegment);
        }
    }

    void OldAlgorithm()
    {//run in start. creates entire level at once.
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
            else if (i <= 10)
            {
                chosenSegment = EasySegments[Random.Range(0, 3 + 1)];//cieling is not inclusive.
            }
            else if (i <= 20)
            {
                chosenSegment = MediumSegments[Random.Range(0, 3 + 1)];//cieling is not inclusive.
                //chosenSegment = MediumSegments[0];//cieling is not inclusive.
            }
            else
            {
                chosenSegment = HardSegments[Random.Range(0, 3 + 1)];//cieling is not inclusive.

            }

            GameObject spawningPlatform = Instantiate(chosenSegment, position, rotation, this.transform);
        }
    }
}
