using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public float keyCounter;
    int DoorID;
    public GameObject[] door;
    public AudioSource sfx;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementCounter(float val_)
    {
        sfx.Play();
        keyCounter += val_;
        if(keyCounter == 1.0f)
        {
            
            GetComponent<AudioSource>().Play();
            door[DoorID].SetActive(false);
            keyCounter = 0;
        }
    }
}
