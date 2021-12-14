using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Popup : MonoBehaviour
{

    [SerializeField]
    private GameObject StoryPanel;

    public void openPopup()
    {
        StoryPanel.SetActive(true);
    }
    public void closePopup()
    {
        StoryPanel.SetActive(false);
    }
    public void backToMainScene()
    {
        SceneManager.LoadScene("Main Scene");//Main Scene
    }
    public void restartGS()
    {
        SceneManager.LoadScene("Game Scene");//Main Scene
    }
    public void restartTS()
    {
        SceneManager.LoadScene("Tutorial Scense");//Main Scene
    }
    public void exit()
    {
        Application.Quit();
    }
}
