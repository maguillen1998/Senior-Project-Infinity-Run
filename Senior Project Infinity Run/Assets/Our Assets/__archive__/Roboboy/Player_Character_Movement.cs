using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Character_Movement : MonoBehaviour
{
    //acceleration and decceleration are both per fixedupdate not per second
    public float acceleration = 0.5f;
    public float decceleration = 2f;
    public float maxSpeed = 4f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;

    bool isGrounded = false;
    int moveDirection = 0;
    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    Transform t;
    Animator myAnim;

    // Use this for initialization
    void Start()
    {
        myAnim = GetComponent<Animator>();
        t = transform;
        mainCollider = GetComponent<CapsuleCollider2D>();
        r2d = GetComponent<Rigidbody2D>();        
        r2d.freezeRotation = true;

        //prevents "Tunneling" through colliders at high speeds
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        r2d.gravityScale = gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement controls
        if (Input.GetKey(KeyCode.A))
        {
            //move right
            moveDirection = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //move left
            moveDirection = 1;
        }
        else
        {
            //dont move
            moveDirection = 0;
        }


        // Change facing direction
        if (moveDirection != 0)
        {
            if (moveDirection > 0)
            {
                //flip GameObject to face right
                t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
            }
            if (moveDirection < 0)
            {
                //flip GameObject to face left
                t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
            }
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
        }
    }

    void FixedUpdate()
    {

        Bounds colliderBounds = mainCollider.bounds;
        float colliderRadius = mainCollider.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);

        // Check if player is grounded
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);

        //Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
        isGrounded = false;
        myAnim.SetBool("jumping", true);
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != mainCollider)
                {
                    isGrounded = true;
                    myAnim.SetBool("jumping", false);
                    break;
                }
            }
        }



        // Apply movement acceleration to velocity
        //if acceleration plus current velocity > max speed, set velocity to max speed

        //not pressing d or a deccelerating
        if (moveDirection == 0)
        {
            //accounting for momentum direction to the right
            if (r2d.velocity.x > 0f)
            {
                float newSlowingSpeedX = r2d.velocity.x - decceleration;

                //ensuring decelleration stops at 0.
                if (newSlowingSpeedX < 0f)
                {
                    r2d.velocity = new Vector2(0, r2d.velocity.y);
                }
                else
                {
                    r2d.velocity = new Vector2(newSlowingSpeedX, r2d.velocity.y);
                }
            }
            //accounting for momentum direction to the left
            if (r2d.velocity.x < 0f)
            {
                float newSlowingSpeedX = r2d.velocity.x + decceleration;

                //ensuring decelleration stops at 0.
                if (newSlowingSpeedX > 0f)
                {
                    r2d.velocity = new Vector2(0, r2d.velocity.y);
                }
                else
                {
                    r2d.velocity = new Vector2(newSlowingSpeedX, r2d.velocity.y);
                }
            }
        }
        else
        {
            float newSpeedX = r2d.velocity.x + acceleration * moveDirection;
            if (Mathf.Abs(newSpeedX) > maxSpeed)
            {

                r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);
            }
            else
            {
                r2d.velocity = new Vector2(newSpeedX, r2d.velocity.y);
            }
        }


        //Updating x-speed variable for the Animator
        myAnim.SetFloat("vSpeed", Mathf.Abs(r2d.velocity.x));


        // Simple debug
        //Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, colliderRadius, 0), isGrounded ? Color.green : Color.red);
        //Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(colliderRadius, 0, 0), isGrounded ? Color.green : Color.red);
    }
}
