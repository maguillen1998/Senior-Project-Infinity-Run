using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1_Hitbox_Behaviors : MonoBehaviour
{
    int AttackDamage = 2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //tell object that you hit them.
        Hit(collision.gameObject);
    }
    void Hit(GameObject target)
    {
        target.GetComponent<Testing_Dummy_Behaviors>().GetHit(AttackDamage);
    }
}
