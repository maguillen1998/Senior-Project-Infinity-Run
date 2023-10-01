using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying_Eye_Controls : MonoBehaviour
{
    string UserInput = "";

    string UpKey = "w";
    string DownKey = "s";
    string LeftKey = "a";
    string RightKey = "d";

    Flying_Eye_Animator_Script AnimatorScript;
    Flying_Eye_Stats Stats;

    //acceleration and decceleration are both per fixedupdate not per second
    public float acceleration = 0.5f;
    public float decceleration = 2f;
    public float maxSpeed = 4f;
    public float jumpForce = 6.5f;
    public float gravityScale = 1.5f;

    bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        AnimatorScript = gameObject.GetComponent<Flying_Eye_Animator_Script>();
        gameObject.GetComponent<Rigidbody2D>().gravityScale = gravityScale;//might be unneccessary when using this line in update
        Stats = gameObject.GetComponent<Flying_Eye_Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = gravityScale;//update gravity from editor
        GetUserInput();
    }

    void FixedUpdate()
    {
        ApplyUserInput();
        
    }

    void GetUserInput()
    {
        UserInput = "";
        if (Input.GetKey(UpKey))
        {
            UserInput = UpKey;
        }
        else if (Input.GetKey(LeftKey))
        {
            UserInput = LeftKey;
        }
        else if (Input.GetKey(DownKey))
        {
            UserInput = DownKey;
        }
        else if (Input.GetKey(RightKey))
        {
            UserInput = RightKey;
        }

        
    }

    void ApplyUserInput()
    {
        float movementSpeedMultiplier = 1;
        if(UserInput == UpKey)
        {
            //jumping
            if (Stats.JumpsSinceGrounded < Stats.MaxJumps && Stats.TimeSinceLastJump() > Stats.JumpDelay)
            {
                Debug.Log("jumps applying: " + Stats.JumpsSinceGrounded);
                Jump();    
            }
        }
        if (UserInput == LeftKey)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            MoveMe(new Vector3(-1 * movementSpeedMultiplier, 0, 0));
        }
        if (UserInput == DownKey)
        {
            
        }
        if (UserInput == RightKey)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            MoveMe(new Vector3(1 * movementSpeedMultiplier,0, 0));
        }

        
    }

    void MoveMe(Vector3 direction)
    {
        Rigidbody2D r2d = gameObject.GetComponent<Rigidbody2D>();
        int moveDirection = Mathf.RoundToInt( direction.x);//temporary solution

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
        //myAnim.SetFloat("vSpeed", Mathf.Abs(r2d.velocity.x));


        // Simple debug
        //Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, colliderRadius, 0), isGrounded ? Color.green : Color.red);
        //Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(colliderRadius, 0, 0), isGrounded ? Color.green : Color.red);
    }

    void Jump()
    {
        Stats.JumpsSinceGrounded += 1;
        Rigidbody2D r2d = gameObject.GetComponent<Rigidbody2D>();
        r2d.velocity = new Vector2(r2d.velocity.x, jumpForce);
        Stats.TimeOfLastJump = Time.fixedTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        CapsuleCollider2D mainCollider = gameObject.GetComponent<CapsuleCollider2D>();
        Bounds colliderBounds = mainCollider.bounds;
        float colliderRadius = mainCollider.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);

        // Check if player is grounded
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);

        //Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
        isGrounded = false;
        //myAnim.SetBool("jumping", true);
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != mainCollider)
                {
                    isGrounded = true;
                    Stats.JumpsSinceGrounded = 0;
                    //myAnim.SetBool("jumping", false);
                    break;
                }
            }
        }
    }

}
