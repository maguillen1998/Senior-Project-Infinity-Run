using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//not in use. simply used once during development to test the skeleton
public interface Base_Monster_Animation_Script_Interface
{//work in progess interface
    void PlayIdle();
    void ResetAttack();

    void PlayAttack1();
    void PlayAttack2();
    void PlayAttack3();

    void PlayDeath();

    void PlayTakeHit();

    public void PlayRun();

    public void PlayJump();

    public void PlayFall();
}
[RequireComponent(typeof(Skeleton_Movement))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class Base_Monster_Animation_Script : MonoBehaviour, Base_Monster_Animation_Script_Interface
{
    Animator Anim;
    Skeleton_Movement MovementController;
    Rigidbody2D r2d;

    //Animation State Names
    string Idle = "Idle";
    string Run = "Run";
    string Death = "Death";
    string Take_Hit = "Take Hit";
    string Attack1 = "Attack1";
    string Attack2 = "Attack2";
    string Attack3 = "Attack3";
    string Jump = "Jump";
    string Fall = "Fall";
    string Shield = "Shield";
    string Projectile = "Projectile";

    public GameObject Attack1Hitbox;



    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        MovementController = GetComponent<Skeleton_Movement>();
        Anim = GetComponent<Animator>();

        //only toggling gameobject results in onentertrigger2d only firing once.
        //toggling the collider directly allows ontriggerenter2d to fire each time we attack
        //Attack1Hitbox.SetActive(true);
        //Attack1Hitbox.GetComponent<PolygonCollider2D>().enabled = false;
    }

    private void Update()
    {

        UpdateAnimations();
    }

    public void PlayIdle()
    {
        Anim.Play(Idle);

    }

    public void PlayAttack1()
    {
        Anim.Play(Attack1);
    }

    public void ResetAttack()
    {
        PlayIdle();
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
        //Destroy(this);
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
        PlayIdle();
    }

    public void PlayFall()
    {
        PlayIdle();
    }

    void UpdateAnimations()
    {
        if(GetComponent<Skeleton_Behaviors>().CurrentHealth <= 0)
        {
            PlayDeath();
            return;
        }
        if (Input.GetKey("space"))
        {
            PlayAttack1();
        }

        if (Anim.GetCurrentAnimatorStateInfo(0).IsName(Attack1))
        {//return to allow the attack animation to finish
            return;
        }

        if (r2d.velocity.x == 0 && r2d.velocity.y == 0)
        {
            PlayIdle();
        }

        if (r2d.velocity.y < 0)
        {
            PlayFall();
        }

        if (r2d.velocity.y > 0)
        {
            PlayJump();
        }

        if (MovementController.isGrounded && Mathf.Abs(r2d.velocity.x) > 0)
        {
            PlayRun();
        }

    }
}
