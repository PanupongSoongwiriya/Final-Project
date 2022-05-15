using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Popup : MonoBehaviour
{

    [SerializeField]
    private GameObject StoryPanel;
    [SerializeField]
    private AudioSource clickBtn;
    [SerializeField]
    private AudioSource clickBtnCancel;

    public void openPopup()
    {
        StoryPanel.SetActive(true);
    }
    public void closePopup()
    {
        StoryPanel.SetActive(false);
        clickBtnCancel.Play();
    }
    public void backToMainScene()
    {
        clickBtn.Play();
        Invoke("ChangeMS", 0.25f);
    }
    private void ChangeMS()
    {
        SceneManager.LoadScene("Main Scene");
    }
    public void restartGS()
    {
        clickBtn.Play();
        Invoke("ChangeGS", 0.25f);
    }
    private void ChangeGS()
    {
        SceneManager.LoadScene("Game Scene");
    }
    public void restartTS()
    {
        clickBtn.Play();
        Invoke("ChangeTS", 0.25f);
    }

    private void ChangeTS()
    {
        SceneManager.LoadScene("Tutorial Scense");
    }
    public void exit()
    {
        clickBtn.Play();
        Invoke("quit", 0.25f);
    }
    private void quit()
    {
        Application.Quit();
    }

}
