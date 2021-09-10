using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    // Start is called before the first frame update
    bool inRange;
    
    public bool beingHeld = false;

    Rigidbody2D rb;
    public LayerMask lMask;
    public GameObject player;
    
    bool buttonPushed;
    public float throwP;
    public float maxThrowP;
    float timer;

    public float mag;

   

    Vector2 defaultPos;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GetComponent<AudioSource>().enabled = false;
        timer = 0.5f;
        rb = GetComponent<Rigidbody2D>();
        maxThrowP = throwP;
        defaultPos = transform.localPosition;

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        if(timer <=0)
            GetComponent<AudioSource>().enabled = true;


        

        buttonPushed = false;
       
            if (Input.GetKeyDown("e") && beingHeld && !buttonPushed) //put the item down
            {
            if (Input.GetKey("s"))
            {
                player.GetComponent<PlayerProperties>().SetIsHolding(false);
                if (player.GetComponent<BasicMotion>().GetFacingLeft() == true)
                    transform.localPosition = new Vector2(-.4f, 0.0f);
                if(player.GetComponent<BasicMotion>().GetFacingLeft() == false)
                    transform.localPosition = new Vector2(.4f, 0.0f);
                beingHeld = false;
            }
            if (beingHeld)
            {
                player.GetComponent<PlayerProperties>().SetIsHolding(false);
                if (player.GetComponent<BasicMotion>().GetFacingLeft() == true)
                    rb.velocity = new Vector2((throwP + -player.GetComponent<Rigidbody2D>().velocity.x) * -1, 0.0f);
                if (player.GetComponent<BasicMotion>().GetFacingLeft() == false)
                    rb.velocity = new Vector2((throwP + player.GetComponent<Rigidbody2D>().velocity.x), 0.0f);
            }
            
            transform.parent = null;
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                beingHeld = false;
            rb.simulated = true;
            buttonPushed = true;
            
            }
        if (inRange)
        {

            
            if (Input.GetKeyDown("e") && !beingHeld && !buttonPushed )//pickup the object
            {
                if (player.GetComponent<PlayerProperties>().GetIsHolding() == false)
                {
                    rb.simulated = false;
                    this.transform.parent = player.transform;
                    transform.localPosition = new Vector2(0, 0.3f);
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    beingHeld = true;
                    buttonPushed = true;
                    player.GetComponent<PlayerProperties>().SetIsHolding(true);
                }
            }
            
        }
        if ((player.transform.position - transform.position).sqrMagnitude < 1.5f)
            inRange = true;
        else
            inRange = false;

       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            
           
            if (rb.velocity.y != 0)
            {
                if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.x < 1.0f && collision.gameObject.GetComponent<Rigidbody2D>().velocity.x > -1.0f && player.transform.position.y < transform.position.y)
                {
                    if (collision.gameObject.GetComponent<BasicMotion>().GetGrounded() == true)
                    {
                        collision.gameObject.GetComponent<PlayerDeath>().Dead();
                        ResetObject();
                    }
                }
            }

        }
        if (collision.gameObject.layer == 6)
        {
            if (!beingHeld)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                if(GetComponent<AudioSource>().isActiveAndEnabled == true)
                GetComponent<AudioSource>().Play();
            }

        }

    }

  



    public void ResetObject()
    {
        transform.position = defaultPos;
        rb.velocity = Vector2.zero;
    }
}
