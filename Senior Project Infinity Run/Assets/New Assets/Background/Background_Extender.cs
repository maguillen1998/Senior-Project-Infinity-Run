using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Extender : MonoBehaviour
{
    public GameObject referenceBackgroundChunk;
    public int ChunksToPlace = 100;
    // Start is called before the first frame update
    void Start()
    {
        float BackgroundChunkWidth = (928f / 32f) * referenceBackgroundChunk.transform.localScale.x; //pixels of sprite on x axis / pixels per unit * scale of chunk

        for (int i = 0; i < ChunksToPlace; i++)
        {
            Vector3 offSet = new Vector3(BackgroundChunkWidth * (float)i, 0, 0);
            GameObject spawnedChunk = Instantiate(referenceBackgroundChunk, this.transform);

            spawnedChunk.transform.position += offSet;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
