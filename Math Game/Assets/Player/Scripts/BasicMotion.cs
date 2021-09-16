using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMotion : MonoBehaviour
{
    // Start is called before the first frame update
   
    Rigidbody2D rb;
    public AudioSource[] sfx;
    public Transform groundCheck;
    public Transform leftWallCheck;
    public Transform rightWallCheck;

    public LayerMask groundMask;

    public Animator anim;

     bool canJump;
     bool canDoubleJump;
     bool hasDoubleJumped;
     bool isGrounded;
     bool isOnLeftWall;
     bool isOnRightWall;
    public bool isDead;
    bool hasInput;

    float regrabTime;
    public float jumpForce;
    public float moveSpeed;
    public float groundDistance;

    bool canDash;
    float dashTimer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isDead)
        {
            
           
            if (regrabTime > 0) //set a timer so the player cant regrab a wall right after jumping off and prevent some input for a moment
            {
                regrabTime -= Time.deltaTime;
            }
            if (dashTimer <= 0)
            {
                rb.gravityScale = 1.0f;
                GroundCheck();
                WallCheck();
                if (Input.GetButtonDown("Jump") && canDoubleJump && !isGrounded && !canJump)
                    DoubleJump();
                if (Input.GetButtonDown("Jump"))
                    Jump();
                if (Input.GetButton("Horizontal"))
                    Move();
                if (Input.GetButtonUp("Horizontal"))
                {
                    if (regrabTime <= 0)
                    {
                        rb.velocity = new Vector2(0, rb.velocity.y);
                        anim.SetBool("isRunning", false);
                        StopAudio(1);
                    }
                }
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    Dash();
                }
                
            }
            else
            {
                anim.SetBool("isRunning", false);
                dashTimer -= Time.deltaTime;
                if (dashTimer <= 0)
                {
                    rb.velocity = Vector2.zero;
                    
                }
            }
        }

    }

    private void Dash()
    {
        if(canDash && dashTimer <= 0)
        {
            rb.gravityScale = 0.0f;
            if(GetFacingLeft() == true)
            rb.velocity = new Vector2(-moveSpeed * 5, 0);
            else
                rb.velocity = new Vector2(moveSpeed * 5, 0);
            dashTimer = 0.2f;
            canDash = false;

            
        }
        
    }
    private void GroundCheck()//check    if the player is standing on the ground. References an invisble circle that looks for the masked layer within a 0.1f radius
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, groundDistance, groundMask);//returns true if standing
        if(!isGrounded)
        {
            anim.SetBool("isJumping", true);
        }
        if (isGrounded)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isDoubleJumping", false);
            anim.SetBool("wallKick", false);
            hasDoubleJumped = false;
            canDoubleJump = true;
            canDash = true;
           
        }

    }
    private void WallCheck()
    {
        
            isOnLeftWall = Physics2D.OverlapCircle(leftWallCheck.transform.position, groundDistance, groundMask);//returns true if standing
            isOnRightWall = Physics2D.OverlapCircle(rightWallCheck.transform.position, groundDistance, groundMask);//returns true if standing
            if (regrabTime <= 0)//ignores the wall grab if the player just left a wall grab via jump
            {
                if (!isGrounded)
                {
                    if (isOnLeftWall || isOnRightWall)
                    {
                    canDash = true;
                    canDoubleJump = true;
                    hasDoubleJumped = false;
                        if (isOnRightWall)
                            gameObject.GetComponent<SpriteRenderer>().flipX = false;
                        if (isOnLeftWall)
                            gameObject.GetComponent<SpriteRenderer>().flipX = true;
                        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
                        anim.SetBool("onWall", true);
                        anim.SetBool("isDoubleJumping", false);

                        anim.SetBool("wallKick", false);

                    }
                }
            }
            if (isGrounded)
                anim.SetBool("onWall", false);
            if (!isOnLeftWall && !isOnRightWall)
                anim.SetBool("onWall", false);
        
        
    }
    private void Jump()
    {
    
        if (isGrounded || canJump) //if the player is on the ground, they can jump
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            canJump = false;
            canDoubleJump = true;
            anim.SetBool("isJumping", true);
            anim.SetBool("isRunning", false);
            PlayAudio(0);
        }
        if (!isGrounded)//if the player is not on the ground, but is grabbing a wall, they can wall kick!
        {
            if (isOnRightWall || isOnLeftWall)
            {
                anim.SetBool("isDoubleJumping", false);
                if (isOnLeftWall)
                {
                    rb.velocity = new Vector2(jumpForce, jumpForce);
                    canDoubleJump = true;
                    canJump = false;
                    anim.SetBool("wallKick", true);
                }
                if (isOnRightWall)
                {
                    rb.velocity = new Vector2(-jumpForce, jumpForce);
                    canDoubleJump = true;
                    canJump = false;
                    anim.SetBool("wallKick", true);
                }
                
                hasDoubleJumped = false;
                regrabTime = .5f; //sets the regrab timer
                canDash = true;
                PlayAudio(0);
            }
           
        }
       
    }
    private void DoubleJump()
    {
        if (canDoubleJump && !hasDoubleJumped) //jumps again if the player is able
        {
            Debug.Log("Flip!");
            anim.SetBool("isDoubleJumping", true);
            anim.SetBool("wallKick", false);

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            canDoubleJump = false;
            hasDoubleJumped = true;
            
            
            anim.SetBool("isRunning", false);
            PlayAudio(0);
        }
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        if (x < 0 && !isOnLeftWall && !isOnRightWall)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            x = -1;
        }
        if (x > 0 && !isOnLeftWall && !isOnRightWall)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            x = 1;
        }

        if(regrabTime <= 0) //player cant adjust movement direction until this timer ticks to 0
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);

        if (isGrounded && anim.GetBool("isRunning") == false)
        {
            Debug.Log("Grounded");
            anim.SetBool("isRunning", true);
            //sfx[1].enabled = true;
            //PlayAudio(1);
        }
        
           
       
           
    }
    private void PlayAudio(int fxID_)
    {
        if(sfx[fxID_].isPlaying == false)
        sfx[fxID_].Play();
    }
    private void StopAudio(int fxID_)
    {
        //sfx[fxID_].Stop();
    }

    public bool GetFacingLeft()
    {
        if (gameObject.GetComponent<SpriteRenderer>().flipX == true)
        {
            return true;
        }
        else return false;
    }
    public bool GetGrounded()
    {
        return isGrounded;
    }
}
