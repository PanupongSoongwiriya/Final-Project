using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStartButton : MonoBehaviour
{
    public void changeScene()
    {
        SceneManager.LoadScene(2);//Story Scene
    }
}
