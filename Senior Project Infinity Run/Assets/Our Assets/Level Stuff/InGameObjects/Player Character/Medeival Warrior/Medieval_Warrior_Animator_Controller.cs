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

    }

    public void PlayAttack1()
    {
        Anim.Play(Attack1);
        this.transform.GetChild(1).GetComponent<AudioSource>().Play();
    }
    
    public void ResetAttack()
    {
        PlayIdle();
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

    }
    public void PlayAttack3()
    {
        Anim.Play(Attack3);

    }

    public void PlayDeath()
    {
        Anim.Play(Death);       
    }

    public void SFXDeath()
    {
        //hardcoded as 2nd child
        this.transform.GetChild(2).GetComponent<AudioSource>().Play();
    }

    public void SFXJump()
    {
        this.transform.GetChild(3).GetComponent<AudioSource>().Play();
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

    public void UpdateAnimations()
    {
        if(GetComponent<Medieval_Warrior_Stats>().CurrentHealth <= 0)
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

        if (r2d.velocity.y < -1)
        {
            PlayFall();
            return;
        }

        if (r2d.velocity.y > 1)
        {
            PlayJump();
        }

        if (MovementController.isGrounded && Mathf.Abs(r2d.velocity.x) > 0)
        {
            PlayRun();
        }
    }

    void TellGameManagerToEndGame()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Game_State_Manager>().EndGame();
    }
}
