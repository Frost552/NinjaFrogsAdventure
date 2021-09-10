using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    // Start is called before the first frame update
    bool isHoldingItem;
    bool isOnGround;
    public Transform spawnPos;
    void Awake()
    {
        transform.position = spawnPos.position;
        spawnPos.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  SetIsHolding(bool b_)
    {
        isHoldingItem = b_;
    }
    public bool GetIsHolding()
    {
        return isHoldingItem;
    }
    public void SetIsOnGround(bool b_)
    {
        isOnGround = b_;
    }
    public bool GetIsOnGround()
    {
        return isOnGround;
    }

    public void NewSpawn(Transform obj_)
    {
        if(spawnPos.gameObject.GetComponent<Animator>() != null)
        spawnPos.gameObject.GetComponent<Animator>().SetBool("FlagUp", false);

        spawnPos = obj_;
        spawnPos.gameObject.GetComponent<Animator>().SetBool("FlagUp", true);
    }
    public void Respawn()
    {
        GetComponent<BasicMotion>().isDead = false;
        GetComponent<Animator>().SetBool("Dead", false);
        transform.position = spawnPos.position;
        
    }
}
