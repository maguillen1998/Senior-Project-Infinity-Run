using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Behaviors : Base_Monster_Behaviors
{
    Skeleton_Movement SM;
    Skeleton_Animation SA;
    // Start is called before the first frame update
    public override void Start()
    {
        SA = GetComponent<Skeleton_Animation>();
        SM = GetComponent<Skeleton_Movement>();
        MaxHealth = 20;
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        SM.controls.shouldMoveRightNextFixedUpdate = true;
        Attack();
    }

    void Attack()
    {//should move into a discreet attack script later
        SA.PlayAttack1();
    }

    
}
