using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medieval_Warrior_Animator_Controller : MonoBehaviour
{
    Animator Anim;
    Medieval_Warrior_Movement MovementController;
    Rigidbody2D r2d;

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

    bool ISAttacking1 = false;
    bool ISAttacking2 = false;
    bool ISAttacking3 = false;
    bool ISJumping = false;
    bool ISFalling = false;
    bool ISTakingHit = false;
    bool ISDead = false;
    bool ISRunning = false;
    bool ISIdle = false;

    //Trigger names
    string Attacking1Trigger = "Attacking1";

    public GameObject Attack1Hitbox;

    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        MovementController = GetComponent<Medieval_Warrior_Movement>();
        Anim = GetComponent<Animator>();

        //only toggling gameobject results in onentertrigger2d only firing once.
        //toggling the collider directly allows ontriggerenter2d to fire each time we attack
        Attack1Hitbox.SetActive(true);
        Attack1Hitbox.GetComponent<PolygonCollider2D>().enabled = false;
    }

    private void Update()
    {
      
        UpdateAnimations();
    }

    public void PlayIdle()
    {
        Anim.Play(Idle);
        ISIdle = true;
    }



    public void PlayAttack1()
    {
        ISAttacking1 = true;
        Anim.Play(Attack1);
                     
    }
    
    public void ResetAttack1()
    {
        ISAttacking1 = false;
    }
    

    public void DeactivateHitboxAttack1()
    {
        //Attack1Hitbox.SetActive(false);
        Attack1Hitbox.GetComponent<PolygonCollider2D>().enabled = false;
    }

    public void ActivateHitboxAttack1()
    {
        // Attack1Hitbox.SetActive(true);
        Attack1Hitbox.GetComponent<PolygonCollider2D>().enabled = true;
    }

    public void PlayAttack2()
    {
        Anim.Play(Attack2);
        ISAttacking2 = true;
    }
    public void PlayAttack3()
    {
        Anim.Play(Attack3);
        ISAttacking3 = true;
    }

    public void PlayDeath()
    {
        Anim.Play(Death);
        ISDead = true;
    }

    public void PlayTakeHit()
    {
        Anim.Play(Take_Hit);
        ISTakingHit = true;
    }

    public void PlayRun()
    {
        Anim.Play(Run);
        ISRunning = true;
    }

    public void PlayJump()
    {
        Anim.Play(Jump);
        ISJumping = true;
    }

    public void PlayFall()
    {
        Anim.Play(Fall);
        ISFalling = true;
    }

    void UpdateAnimations()
    {
        Debug.Log("attacking trigger: " + ISAttacking1);
       

        

        if (!ISAttacking1)
        {
            if (Input.GetKeyDown("space"))
            {
                PlayAttack1();
               
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
}
