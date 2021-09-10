using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            collision.gameObject.GetComponent<PlayerProperties>().NewSpawn(gameObject.transform);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
