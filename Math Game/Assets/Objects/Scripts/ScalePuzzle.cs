using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePuzzle : MonoBehaviour
{
    public GameObject[] Scales; //0 left, 1 right
    float left, right;
    float leftPosY, rightPosY;
    public float clampF;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        left = Scales[0].GetComponent<WeightData>().GetWeight();
        right = Scales[1].GetComponent<WeightData>().GetWeight();

        if (left > right)
        {
            leftPosY = Scales[0].transform.localPosition.y;
            leftPosY -= Time.deltaTime;
            Scales[0].transform.localPosition = new Vector2(Scales[0].transform.localPosition.x, Mathf.Clamp(leftPosY, clampF * -1, clampF));

            rightPosY = Scales[1].transform.localPosition.y;
            rightPosY += Time.deltaTime;
            Scales[1].transform.localPosition = new Vector2(Scales[1].transform.localPosition.x, Mathf.Clamp(rightPosY, clampF * -1, clampF));

        }
        if (right > left)
        {
            leftPosY = Scales[0].transform.localPosition.y;
            leftPosY += Time.deltaTime;
            Scales[0].transform.localPosition = new Vector2(Scales[0].transform.localPosition.x, Mathf.Clamp(leftPosY, clampF * -1, clampF));

            rightPosY = Scales[1].transform.localPosition.y;
            rightPosY -= Time.deltaTime;
            Scales[1].transform.localPosition = new Vector2(Scales[1].transform.localPosition.x, Mathf.Clamp(rightPosY, clampF * -1, clampF));

        }
        if (right == left)
        {
            if (leftPosY > rightPosY)
            {
                leftPosY = Scales[0].transform.localPosition.y;
                leftPosY -= Time.deltaTime;
                Scales[0].transform.localPosition = new Vector2(Scales[0].transform.localPosition.x, Mathf.Clamp(leftPosY, 0, 1));

                rightPosY = Scales[1].transform.localPosition.y;
                rightPosY += Time.deltaTime;
                Scales[1].transform.localPosition = new Vector2(Scales[1].transform.localPosition.x, Mathf.Clamp(rightPosY, -1, 0));

            }
            if (rightPosY > leftPosY)
            {
                leftPosY = Scales[0].transform.localPosition.y;
                leftPosY += Time.deltaTime;
                Scales[0].transform.localPosition = new Vector2(Scales[0].transform.localPosition.x, Mathf.Clamp(leftPosY, -1, 0));

                rightPosY = Scales[1].transform.localPosition.y;
                rightPosY -= Time.deltaTime;
                Scales[1].transform.localPosition = new Vector2(Scales[1].transform.localPosition.x, Mathf.Clamp(rightPosY, 0, 1));



            }

        }
    }

}