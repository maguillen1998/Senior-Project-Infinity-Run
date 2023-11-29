using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikebehaviors : MonoBehaviour
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
        //if colliding with the PC, spikes deal 1HP damage to the PC

        IHitHandler hitHandler = collision.gameObject.GetComponent<IHitHandler>();
        hitHandler.HandleHit(1);
        //Debug.Log("PC touched Spike. HealthPoints: " + collision.gameObject.GetComponent<Player_Character_Stats>().HealthPoints);
        
    }
}
