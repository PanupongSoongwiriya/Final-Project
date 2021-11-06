
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{
    public StorySystem ss;
    void Start()
    {
        ss = GameObject.Find("StorySystem").GetComponent<StorySystem>();
        //transform.GetChild(0).GetChild(0).GetComponent<Text>().text = ThaiFontAdjuster.Adjust("กดตรงไหนก็ได้เพื่อไปหน้าเกมเพลย์ " + ss.sm.state.storyOrder);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            changeScene();
        }
    }
    public void changeScene()
    {
        /*if (ss.sm.state.storyOrder != -1)
        {
            SceneManager.LoadScene("Game Scene");
        }
        else
        {
            SceneManager.LoadScene("Tutorial Scense");
        }*/
    }
}
