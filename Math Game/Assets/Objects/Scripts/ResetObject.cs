using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObject : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 startPos;
    public float killPlane = -50.0f;
    void Start()
    {
        startPos = transform.position;
        if(killPlane == 0.0f)
        {
            killPlane = -50.0f;
            Debug.Log("Killplan not set on " + gameObject.name + " setting to -50.0f");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= killPlane)
        {
            transform.position = startPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("OOB"))
        {
            if (gameObject.GetComponent<Lift>().beingHeld == false)
            {
                transform.position = startPos;
            }
        }
    }
}
