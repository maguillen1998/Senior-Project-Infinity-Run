using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLExtender : MonoBehaviour
{
    public GameObject referenceBackgroundChunk;
    public int ChunksToPlace = 100;
    // Start is called before the first frame update
    void Start()
    {
        // Get the dimensions of the sprite.
        SpriteRenderer sprite = referenceBackgroundChunk.GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            Vector2 spriteDimensions = sprite.bounds.size;
            //float spriteWidth = (928f / 32f) * referenceBackgroundChunk.transform.localScale.x; //manually do: pixels of sprite on x axis / pixels per unit * scale of chunk
            float spriteWidth = spriteDimensions.x;
            for (int i = 0; i < ChunksToPlace; i++)
            {
                Vector3 offSet = new Vector3(spriteWidth * (float)i, 0, 0);
                GameObject spawnedChunk = Instantiate(referenceBackgroundChunk, this.transform);

                spawnedChunk.transform.position += offSet;              
            }
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
