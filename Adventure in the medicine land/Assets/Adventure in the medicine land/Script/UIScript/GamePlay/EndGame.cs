using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class EndGame : MonoBehaviour
{
    public GameSystem gameSystem;
    public GameObject win;
    public GameObject lose;
    public GameObject againButton;
    public GameObject back2HomeButton;
    public GameObject continuousButton;
    public Animator anim;
    public SaveManager sm;
    [SerializeField]
    private AudioSource sound_Win;
    [SerializeField]
    private AudioSource sound_Lose;
    public int saveManager;
    void Start()
    {
        try
        {
            gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        }
        catch (Exception e)
        {
            gameSystem = GameObject.Find("TutorialSystem").GetComponent<GameSystem>();
        }
    }

    public void checkTheWin()
    {
        bool checkWin = gameSystem.diseaseFaction.Count == 0;
        bool checkLose = gameSystem.medicineFaction.Count == 0;
        if (checkWin)
        {
            if (saveManager == 3)
            {
                Invoke("goToStoryScene", 4f);
            }
            gameSystem.BGM.Stop();
            sound_Win.Play();
            AutoSeve();
        }
        else
        {
            gameSystem.BGM.Stop();
            sound_Lose.Play();
        }
        win.SetActive(checkWin);
        lose.SetActive(checkLose);
        againButton.SetActive(checkLose);
        continuousButton.SetActive(checkWin && saveManager != 3);
        back2HomeButton.SetActive(true && !(saveManager == 3 && checkWin));
        fadeToBlack();
    }

    //Case Lose
    public void playAgain()
    {
        gameObject.SetActive(false);
        lose.SetActive(false);
        againButton.SetActive(false);
        back2HomeButton.SetActive(false);
        gameSystem.resetGame();
    }

    public void backToMainScene()
    {
        SceneManager.LoadScene("Main Scene");//Main Scene
    }

    //Case Win
    public void goToStoryScene()
    {
        SceneManager.LoadScene("Story Scene");//Story Scene
    }
    public void fadeToBlack()
    {
        anim.SetBool("FadeIn", false);
        anim.SetBool("FadeOut", true);
    }
    public void AutoSeve()
    {
        sm.state.storyOrder = Mathf.Min(sm.state.storyOrder + 1, 4);
        sm.Save();
        Debug.Log("AutoSeve");
    }
}
