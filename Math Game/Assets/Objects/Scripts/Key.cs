using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update
    public DoorHandler keyCount;
    public float keyValue;
    void Start()
    {
        keyCount = GameObject.FindGameObjectWithTag("EventManager").GetComponent<DoorHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if(collision.gameObject.CompareTag("Player"))
        {
           
            keyCount.IncrementCounter(keyValue);
            this.gameObject.SetActive(false);
        }
    }
}
