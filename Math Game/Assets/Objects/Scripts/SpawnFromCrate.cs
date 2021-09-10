using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFromCrate : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        float x, y;
        x = Random.Range(-5, 5);
        y = Random.Range(0, 5);

        transform.rotation =new Quaternion(0f, 0f, 0f, 0f);

        GetComponent<Rigidbody2D>().velocity = new Vector2(x, y);
    }

  
}
