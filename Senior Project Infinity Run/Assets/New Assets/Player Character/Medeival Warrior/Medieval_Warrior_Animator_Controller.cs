using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medieval_Warrior_Animator_Controller : MonoBehaviour
{
    Animator Anim;

    //Animation State Names
    string Idle = "Idle";
    string Run = "Run";
    string Death = "Death";
    string Take_Hit = "Get Hit";
    string Attack1 = "Attack1";
    string Attack2 = "Attack2";
    string Attack3 = "Attack3";
    string Jump = "Jump";
    string Fall = "Fall";

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    public void PlayIdle()
    {
        Anim.Play(Idle);
    }

    public void PlayAttack1()
    {
        Anim.Play(Attack1);
    }

    public void PlayAttack2()
    {
        Anim.Play(Attack2);
    }
    public void PlayAttack3()
    {
        Anim.Play(Attack3);
    }

    public void PlayDeath()
    {
        Anim.Play(Death);
    }

    public void PlayTakeHit()
    {
        Anim.Play(Take_Hit);
    }

    public void PlayRun()
    {
        Anim.Play(Run);
    }

    public void PlayJump()
    {
        Anim.Play(Jump);
    }

    public void PlayFall()
    {
        Anim.Play(Fall);
    }
}
