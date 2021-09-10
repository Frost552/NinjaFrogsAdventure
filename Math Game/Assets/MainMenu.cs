using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public string levelString;
    public GameObject[] Buttons;

    private void Start()
    {
        Cursor.visible = true;
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
    }
}
