using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isFalling;
    public float startY, y;
    Rigidbody2D rb;
    void Start()
    {
        startY = transform.localPosition.y;
        y = startY;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFalling)
        {
            rb.velocity = new Vector2(0, -3.0f);
        }
        if(!isFalling)
        {
            if (transform.localPosition.y < startY)
                rb.velocity = new Vector2(0, 1.0f);
            else
            {
                rb.velocity = Vector2.zero;
                transform.localPosition = new Vector2(transform.localPosition.x, startY);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {
            isFalling = true;
        }
        if (collision.gameObject.layer == 6)
        {
            isFalling = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isFalling = false;
        }
    }

}
