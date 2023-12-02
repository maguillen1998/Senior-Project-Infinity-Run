using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviors : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.GetChild(0).GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rotate about the y axis
        //this.transform.Rotate(this.transform.rotation.x, this.transform.rotation.y - 15f, this.transform.rotation.z, Space.Self);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //convert this into a more universal script using an interface
        //collision.gameObject.GetComponent<Medieval_Warrior_Stats>().CoinsCollected += 1;
        collision.gameObject.GetComponent<Medieval_Warrior_Stats>().CollectCoin();
        //update coin UI
        GameObject.FindGameObjectWithTag("CoinUIRenderer").GetComponent<CoinsUIUpdater>().UpdateDisplayedCoinCount(collision.gameObject.GetComponent<Medieval_Warrior_Stats>().CoinsCollected);
        Destroy(this.gameObject);
        Debug.Log("PC touched Coin. CoinsCollected: " + collision.gameObject.GetComponent<Medieval_Warrior_Stats>().CoinsCollected);
    }
    
}
