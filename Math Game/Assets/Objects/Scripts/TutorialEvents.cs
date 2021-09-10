using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEvents : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] videoOBJ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayVideo(int i_, GameObject obj_)
    {
        obj_.SetActive(false);
        videoOBJ[i_].SetActive(true);
    }
    public void StopVideo(int i_, GameObject obj_)
    {
        obj_.SetActive(false);
        videoOBJ[i_].SetActive(false);
    }
}
