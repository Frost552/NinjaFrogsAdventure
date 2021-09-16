using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMotion : MonoBehaviour
{
    // Start is called before the first frame update
    float pos;
    public float mag;
    public float freq;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position.y;
        pos += Mathf.Sin(Time.time * freq) * mag;
        transform.position = new Vector2(transform.position.x, pos);
    }
}
