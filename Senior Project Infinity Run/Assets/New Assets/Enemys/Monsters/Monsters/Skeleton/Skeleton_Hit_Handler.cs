using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Hit_Handler : MonoBehaviour//add back ihithandler funcs after demo
{
    public void HandleHit(int damageAmount)
    {
        gameObject.GetComponent<Skeleton_Stats>().CurrentHealth -= damageAmount;

        Debug.Log(this.name + "was hit. HP remaing: " + gameObject.GetComponent<Skeleton_Stats>().CurrentHealth);

        if(gameObject.GetComponent<Skeleton_Stats>().CurrentHealth <= 0)
        {
            GetComponent<Skeleton_Animation>().PlayDeath();
        }
    }

    public void DestroySelf()
    {
        Destroy(this);
    }
}