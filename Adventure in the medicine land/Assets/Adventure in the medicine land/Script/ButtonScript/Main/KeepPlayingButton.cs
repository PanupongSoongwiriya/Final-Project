using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class KeepPlayingButton : MonoBehaviour
{
    public void changeScene()
    {
        SceneManager.LoadScene(2);//Story Scene
    }
}
