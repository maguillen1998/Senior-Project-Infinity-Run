using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Hit_Handler : MonoBehaviour, IHitHandler
{
    public void HandleHit(int damageAmount)
    {
        gameObject.GetComponent<Skeleton_Stats>().CurrentHealth -= damageAmount;

        Debug.Log(this.name + "was hit. HP remaing: " + gameObject.GetComponent<Skeleton_Stats>().CurrentHealth);
    }
}