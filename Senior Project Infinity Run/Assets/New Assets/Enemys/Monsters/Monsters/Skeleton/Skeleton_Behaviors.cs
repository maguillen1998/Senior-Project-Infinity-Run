using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Behaviors : Base_Monster_Behaviors
{
    // Start is called before the first frame update
    public override void Start()
    {
        MaxHealth = 20;
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
