using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            changeScene();
        }
    }
    public void changeScene()
    {
        SceneManager.LoadScene(3);//Game Play Scene
    }
}
