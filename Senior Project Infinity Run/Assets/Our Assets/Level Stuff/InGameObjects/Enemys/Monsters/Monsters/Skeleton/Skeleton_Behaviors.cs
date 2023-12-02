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
    bool dead = false;
    public override void Start()
    {
        SA = GetComponent<Skeleton_Animation>();
        SM = GetComponent<Skeleton_Movement>();

    }

    // Update is called once per frame
    void Update()
    {
        //SM.controls.shouldMoveRightNextFixedUpdate = true;
       
        if(CurrentHealth <= 0)
        {
            //Die();
            return;
        }
        if(!dead && Time.realtimeSinceStartup - TimeOfLastAttack > AttackDelaySeconds)
        {
            Attack();
            TimeOfLastAttack = Time.realtimeSinceStartup;
        }
    }

    void Attack()
    {//should move into a discreet attack script later
        SA.PlayAttack1();
        this.transform.GetChild(1).GetComponent<AudioSource>().Play();
    }

    public override void Die()
    {
        SA.PlayDeath();
        this.transform.GetChild(2).GetComponent<AudioSource>().Play();
        //dead = true;
    }

    public void DestroySelf()
    {
        this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}
