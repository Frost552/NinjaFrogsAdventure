using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PowerUp"))
        {
            GameObject obj = collision.gameObject;

            string itemCall = obj.GetComponent<ItemCalls>().GetItemName();

            if(itemCall == "Star")
            {
                GetComponent<PlayerProperties>().hasStars = true;
                collision.gameObject.SetActive(false);
            }
            if (itemCall == "Dash")
            {
                GetComponent<PlayerProperties>().hasDash = true;
                collision.gameObject.SetActive(false);
            }
        }      
    }
}
