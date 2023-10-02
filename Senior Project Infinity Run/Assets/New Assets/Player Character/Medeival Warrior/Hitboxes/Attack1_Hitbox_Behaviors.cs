using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1_Hitbox_Behaviors : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        //tell object that you hit them.

        //Hit(collision.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //tell object that you hit them.

        Hit(collision.gameObject);
    }
    void Hit(GameObject target)
    {
        
        target.GetComponent<testing_dummy_behavior>().OnHit();
    }
}
