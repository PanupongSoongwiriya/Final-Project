using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public void changeScene()
    {
        SceneManager.LoadScene(0);//Main Scene
    }
}
