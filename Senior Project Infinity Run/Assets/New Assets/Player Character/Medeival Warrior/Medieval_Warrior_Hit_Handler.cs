using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medieval_Warrior_Hit_Handler : MonoBehaviour, IHitHandler
{
    public void HandleHit(int damageAmount)
    {
        gameObject.GetComponent<Medieval_Warrior_Stats>().CurrentHealth -= damageAmount;

        Debug.Log("medwar hit HP: " + gameObject.GetComponent<Medieval_Warrior_Stats>().CurrentHealth);
    }
}
