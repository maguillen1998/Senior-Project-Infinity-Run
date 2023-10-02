using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//class
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Skeleton_Stats))]
public class Skeleton_Movement : MonoBehaviour
{
    public struct Skeleton_Movement_Booleans
    {


        public bool shouldJumpNextFixedUpdate;
        public bool shouldMoveRightNextFixedUpdate;
        public bool shouldMoveLeftNextFixedUpdate;
        public bool shouldMoveDownNextFixedUpdate;//no bound functionality atm

        public void Initialize()
        {
            shouldJumpNextFixedUpdate = false;
            shouldMoveRightNextFixedUpdate = false;
            shouldMoveLeftNextFixedUpdate = false;
            shouldMoveDownNextFixedUpdate = false;
        }
    }
    string UpKey = "w";
    string DownKey = "s";
    string LeftKey = "a";
    string RightKey = "d";

    public Skeleton_Movement_Booleans controls;


    Rigidbody2D r2d;
    Skeleton_Stats Stats;

    //acceleration and decceleration are both per fixedupdate not per second
    public float acceleration = 0.5f;
    public float decceleration = 2f;
    public float maxSpeed = 4f;
    public float jumpForce = 6.5f;
    public float gravityScale = 1.5f;

    public bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {

        controls.Initialize();

        r2d = gameObject.GetComponent<Rigidbody2D>();
        r2d.gravityScale = gravityScale;//might be unneccessary when using this line in update
        r2d.freezeRotation = true;

        Stats = gameObject.GetComponent<Skeleton_Stats>();
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
        //for these getkeydown checks, need to set flag to true here and set it to false in applyuserinput. any resets here will cause missed inputs
        if (Input.GetKeyDown(UpKey))//testing change to keydown
        {
            //controls.shouldJumpNextFixedUpdate = true; // skeletons cant jump
        }

        //for these getkey checks, we need to set reset each boolean before assinging them again.
        controls.shouldMoveLeftNextFixedUpdate = false;
        if (Input.GetKey(LeftKey))
        {
            controls.shouldMoveLeftNextFixedUpdate = true;
        }

        controls.shouldMoveDownNextFixedUpdate = false;
        if (Input.GetKey(DownKey))
        {
            controls.shouldMoveDownNextFixedUpdate = true;
        }

        controls.shouldMoveRightNextFixedUpdate = false;
        if (Input.GetKey(RightKey))
        {
            controls.shouldMoveRightNextFixedUpdate = true;
        }
    }

    void ApplyUserInput()
    {
        float movementSpeedMultiplier = 1;
        if (controls.shouldJumpNextFixedUpdate)
        {
            //jumping
            if (Stats.JumpsSinceGrounded < Stats.MaxJumps && Stats.TimeSinceLastJump() > Stats.JumpDelay)
            {
                Jump();
            }
            controls.shouldJumpNextFixedUpdate = false;
        }
        if (controls.shouldMoveLeftNextFixedUpdate)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            MoveMe(new Vector3(-1 * movementSpeedMultiplier, 0, 0));
        }
        if (controls.shouldMoveDownNextFixedUpdate)
        {
            //no behaviors atm
        }
        if (controls.shouldMoveRightNextFixedUpdate)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            MoveMe(new Vector3(1 * movementSpeedMultiplier, 0, 0));
        }

    }

    void MoveMe(Vector3 direction)
    {
        Rigidbody2D r2d = gameObject.GetComponent<Rigidbody2D>();
        int moveDirection = Mathf.RoundToInt(direction.x);//temporary solution

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

        isGrounded = false;
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
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != mainCollider)
                {
                    isGrounded = true;
                    Stats.JumpsSinceGrounded = 0;
                    break;
                }
            }
        }
    }
}
