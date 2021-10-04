using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameSystem gameSystem;
    public GameObject win;
    public GameObject lose;
    public GameObject yesButton;
    public GameObject noButton;
    public Animator anim;

    public void checkTheWin()
    {
        bool checkWin = gameSystem.diseaseFaction.Count == 0;
        bool checkLose = gameSystem.medicineFaction.Count == 0;
        win.SetActive(checkWin);
        lose.SetActive(checkLose);
        yesButton.SetActive(checkLose);
        noButton.SetActive(checkLose);
        if (checkWin)
        {
            AutoSeve();
            Invoke("fadeToBlack", 1.5f);
            Invoke("goToStoryScene", 3f);
        }
        else if (checkLose)
        {
            fadeToBlack();
        }
    }

    //Case Lose
    public void playAgain()
    {
        gameObject.SetActive(false);
        lose.SetActive(false);
        yesButton.SetActive(false);
        noButton.SetActive(false);
        gameSystem.resetGame();
    }

    public void backToMainScene()
    {
        SceneManager.LoadScene(0);//Main Scene
    }

    //Case Win
    public void goToStoryScene()
    {
        SceneManager.LoadScene(2);//Story Scene
    }
    public void fadeToBlack()
    {
        anim.SetBool("FadeIn", false);
        anim.SetBool("FadeOut", true);
    }
    public void AutoSeve()
    {
        Debug.Log("AutoSeve");
    }
}
