using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStartButton : MonoBehaviour
{
    public SaveManager sm;
    [SerializeField]
    private GameObject AreYouSure;
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
        sm.resetState();
        SceneManager.LoadScene("Story Scene");
    }
}
