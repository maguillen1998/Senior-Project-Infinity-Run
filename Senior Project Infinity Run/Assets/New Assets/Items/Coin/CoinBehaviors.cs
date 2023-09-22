using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviors : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if colliding with the PC, coins increment the PC coin counter
        if (collision.gameObject.tag == "Player Character")
        {
            collision.gameObject.GetComponent<Player_Character_Stats>().CoinsCollected += 1;
            Destroy(this.gameObject);
            Debug.Log("PC touched Coin. CoinsCollected: " + collision.gameObject.GetComponent<Player_Character_Stats>().CoinsCollected);
        }
    }
}
