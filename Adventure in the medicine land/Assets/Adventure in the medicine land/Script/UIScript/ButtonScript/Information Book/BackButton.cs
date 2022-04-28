using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public void changeScene()
    {
        Invoke("Change", 0.25f);
    }

    private void Change()
    {
        SceneManager.LoadScene(0);//Main Scene
    }
}
