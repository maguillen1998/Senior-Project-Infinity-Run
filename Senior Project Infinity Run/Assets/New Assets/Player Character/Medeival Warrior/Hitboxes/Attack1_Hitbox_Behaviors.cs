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
        //getting the base monster class allows us to call the same method on any monster we hit without needing to reference the derived script directly.
        //override on the derived class will allow it to still give us the correct gethit method even after changing it in the derived class.
        target.gameObject.GetComponent<Base_Monster_Behaviors>().GetHit(AttackDamage);
    }
}
