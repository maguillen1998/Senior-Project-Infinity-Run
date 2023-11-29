using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Attack_1_Hitbox : MonoBehaviour
{
    int AttackDamage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(this.name + " Collided with " + collision.name);
        //tell object that you hit them.
        IHitHandler hitHandler = collision.gameObject.GetComponent<IHitHandler>();
        if (hitHandler == null)
        {
            Debug.Log("HitHandler not found on: " + collision.name);
            return;
        }
        hitHandler.HandleHit(AttackDamage);
    }
}
