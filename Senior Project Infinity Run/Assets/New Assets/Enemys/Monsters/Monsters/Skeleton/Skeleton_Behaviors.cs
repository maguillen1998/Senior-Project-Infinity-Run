using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Behaviors : Base_Monster_Behaviors
{
    Skeleton_Movement SM;
    Skeleton_Animation SA;

    float TimeOfLastAttack = 0f;
    float AttackDelaySeconds = 1f;
    // Start is called before the first frame update
    public override void Start()
    {
        SA = GetComponent<Skeleton_Animation>();
        SM = GetComponent<Skeleton_Movement>();
        MaxHealth = 1;
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //SM.controls.shouldMoveRightNextFixedUpdate = true;
       
        if(Time.realtimeSinceStartup - TimeOfLastAttack > AttackDelaySeconds)
        {
            Attack();
            TimeOfLastAttack = Time.realtimeSinceStartup;
        }
    }

    void Attack()
    {//should move into a discreet attack script later
        SA.PlayAttack1();
    }

    
}
