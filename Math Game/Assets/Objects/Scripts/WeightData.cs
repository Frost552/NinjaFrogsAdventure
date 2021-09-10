using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightData : MonoBehaviour
{
    // Start is called before the first frame update

   public float weight;
    private void Update()
    {
        
    }
    public float GetWeight()
    {
        return weight; 
    }
    public void SetWeight(float weight_)
    {
        weight += weight_;
    }
}
