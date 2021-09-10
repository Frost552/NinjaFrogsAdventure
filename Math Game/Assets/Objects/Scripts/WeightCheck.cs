using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public float heldWeight;
    public GameObject WeightPad;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WeightObject") || collision.gameObject.CompareTag("Player"))
        {
            WeightPad.GetComponent<WeightData>().SetWeight(collision.gameObject.GetComponent<WeightFactor>().GetWeightValue());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WeightObject") || collision.gameObject.CompareTag("Player"))
        {
            WeightPad.GetComponent<WeightData>().SetWeight(-collision.gameObject.GetComponent<WeightFactor>().GetWeightValue());
        }
    }
    public void AddWeight(float w_)
    {
        heldWeight += w_;
    }
    public void RemoveWeight(float w_)
    {
        heldWeight -= w_;
    }

    public float GetWeight()
    {
        return heldWeight;
    }

}
