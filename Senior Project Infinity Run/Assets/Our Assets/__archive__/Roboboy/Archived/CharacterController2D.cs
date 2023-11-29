using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class CharacterController2D : MonoBehaviour
{
    public Animator myAnim;
    
    //acceleration and decceleration are both per fixedupdate not per second
    public float acceleration = 0.5f;
    public float decceleration = 2f;
    public float maxSpeed = 4f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;

    //public Camera mainCamera;

    bool facingRight = true;
    float moveDirection = 0;
    bool isGrounded = false;
    // Vector3 cameraPos;
    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    Transform t;

    // Use this for initialization
    void Start()
    {
        myAnim = GetComponent<Animator>();
        t = transform;
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;
        /*
         * archive
        mainCamera = Camera.main;
        if (mainCamera)
        {
            cameraPos = mainCamera.transform.position;
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
        // Movement controls
        
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDirection = 1;
        }
        else
        {
            moveDirection = 0;
        }
        

        // Change facing direction
        if (moveDirection != 0)
        {
            if (moveDirection > 0)
            {
                t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
                Debug.Log("moving right");
            }
            if (moveDirection < 0)
            {
                t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
                Debug.Log("moving left");
            }
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
        }

        /*
        // Camera follow
        if (mainCamera)
        {
            mainCamera.transform.position = new Vector3(t.position.x, cameraPos.y, cameraPos.z);
        }
        */
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
            if(r2d.velocity.x > 0f)
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