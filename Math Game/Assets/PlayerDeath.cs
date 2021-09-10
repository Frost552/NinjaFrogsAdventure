using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    // Start is called before the first frame update
    float timer;
    bool dead;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            if (timer > 0.0f)
                timer -= Time.deltaTime;
            else
            {
                GetComponent<PlayerProperties>().Respawn();
                gameObject.GetComponent<Animator>().SetBool("Dead", false);
                dead = false;
            }
        }
    }

    public void Dead()
    {

        timer = 0.586f;
        
        gameObject.GetComponent<Animator>().SetBool("isJumping", false);
        gameObject.GetComponent<Animator>().SetBool("isDoubleJumping", false);
        gameObject.GetComponent<Animator>().SetBool("isRunning", false);
        gameObject.GetComponent<Animator>().SetBool("onWall", false);
        gameObject.GetComponent<Animator>().SetBool("wallKick", false);
        gameObject.GetComponent<Animator>().SetBool("Dead", true);

        dead = true;
        GetComponent<BasicMotion>().isDead = true;
    }
}
