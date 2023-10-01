using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generic_Monster_Animation_Script : MonoBehaviour
{
    Animator Anim;

    //Animation State Names
    string Idle = "Idle";
    string Run = "Run";
    string Projectile = "Projectile";
    string Death = "Death";
    string Take_Hit = "Take Hit";
    string Attack1 = "Attack1";
    string Attack2 = "Attack2";
    string Attack3 = "Attack3";
    string Shield = "Shield";

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Anim.Play(Idle);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Anim.Play(Attack1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Anim.Play(Attack2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Anim.Play(Attack3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Anim.Play(Death);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Anim.Play(Take_Hit);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Anim.Play(Run);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Anim.Play(Projectile);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Anim.Play(Shield);
        }
    }
}
