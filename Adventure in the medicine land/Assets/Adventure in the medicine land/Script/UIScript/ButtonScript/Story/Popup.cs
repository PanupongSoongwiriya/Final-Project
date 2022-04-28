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
        Invoke("ChangeMS", 0.25f);
    }
    private void ChangeMS()
    {
        SceneManager.LoadScene("Main Scene");
    }
    public void restartGS()
    {
        Invoke("ChangeGS", 0.25f);
    }
    private void ChangeGS()
    {
        SceneManager.LoadScene("Game Scene");
    }
    public void restartTS()
    {
        Invoke("ChangeTS", 0.25f);
    }

    private void ChangeTS()
    {
        SceneManager.LoadScene("Tutorial Scene");
    }
    public void exit()
    {
        Invoke("quit", 0.25f);
    }
    private void quit()
    {
        Application.Quit();
    }

}
