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

        //convert this into a more universal script using an interface
        collision.gameObject.GetComponent<Medieval_Warrior_Stats>().CoinsCollected += 1;
        //update coin UI
        GameObject.FindGameObjectWithTag("CoinUIRenderer").GetComponent<CoinsUIUpdater>().UpdateDisplayedCoinCount(collision.gameObject.GetComponent<Medieval_Warrior_Stats>().CoinsCollected);
        Destroy(this.gameObject);
        Debug.Log("PC touched Coin. CoinsCollected: " + collision.gameObject.GetComponent<Medieval_Warrior_Stats>().CoinsCollected);
    }
    
}
