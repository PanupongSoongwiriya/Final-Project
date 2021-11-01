using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStartButton : MonoBehaviour
{
    public GameObject AreYouSure;

    public void AreYouSureVisible()
    {
        AreYouSure.SetActive(true);
    }
    public void AreYouSureHidden()
    {
        AreYouSure.SetActive(false);
    }
    public void changeScene()
    {
        SceneManager.LoadScene("Tutorial Scense");//Story Scene
    }
}
