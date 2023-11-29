using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Testing_Dummy_Behaviors : Base_Monster_Behaviors
{
    public override void Start()
    {
        MaxHealth = 5;
        CurrentHealth = MaxHealth;
    }
}
