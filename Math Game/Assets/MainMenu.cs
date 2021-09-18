using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public string levelString;
    public GameObject[] Buttons;
    public int debugcount = 0;
    private void Start()
    {
        Cursor.visible = true;

       
    }
    private void Update()
    {
        if (Input.GetKeyDown("a") && debugcount == 0)
        {
            debugcount++;
        }
        else if (Input.GetKeyDown("k") && debugcount == 1)
        {
            debugcount++;
        }
        else if (Input.GetKeyDown("e") && debugcount == 2)
        {
            debugcount++;
        }
        else if (Input.GetKeyDown("n") && debugcount == 3)
        {
            debugcount++;
        }
        else if (Input.GetKeyDown("o") && debugcount == 4)
        {
            Buttons[3].SetActive(true);
        }
        
    }
    public void OnPress(int i_)
    {
        //for(int j = 0; j < Buttons.Length; j++)
        //{
        //    if(j != i_)
        //    {
        //        Buttons[j].SetActive(false);
        //    }
        //}

        //for (int j = 0; j < Buttons.Length; j++)
        //{
        //    if (i_ > Buttons.Length)
        //    {
        //        Buttons[j].SetActive(true);
        //    }
        //}

        if(i_ == 0)
        {
            SceneManager.LoadScene(levelString, LoadSceneMode.Single);
        }
        if(i_ == 2)
        {
            Application.Quit();
        }
        if (i_ == 4)
        {
            SceneManager.LoadScene("TestStage", LoadSceneMode.Single);
        }
    }
}
