using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class VictoryFlag : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audiosfx;
    bool transitionStage;
    float timer;
    public string nextStage;
    void Start()
    {
        transitionStage = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(transitionStage && timer > 0)
        {
            timer-= Time.deltaTime;
            if(timer <= 0)
            {
                SceneManager.LoadScene(nextStage, LoadSceneMode.Single);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            audiosfx.Play();
            timer = 5.0f;
            transitionStage = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
