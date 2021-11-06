using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStartButton : MonoBehaviour
{
    public GameObject AreYouSure;
    public bool firstPlay;

    public void AreYouSureVisible()
    {
        if (firstPlay)
        {
            changeScene();
        }
        else
        {
            AreYouSure.SetActive(true);
        }
    }
    public void AreYouSureHidden()
    {
        AreYouSure.SetActive(false);
    }
    public void changeScene()
    {
        SceneManager.LoadScene("Story Scene");
    }
}
