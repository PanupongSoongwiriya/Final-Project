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
    public SaveManager sm;

    public void checkTheWin()
    {
        bool checkWin = gameSystem.diseaseFaction.Count == 0;
        bool checkLose = gameSystem.medicineFaction.Count == 0;
        win.SetActive(checkWin);
        lose.SetActive(checkLose);
        yesButton.SetActive(checkLose);
        noButton.SetActive(checkLose);
        fadeToBlack();
        if (checkWin)
        {
            AutoSeve();
            Invoke("goToStoryScene", 3f);
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
        sm.state.storyOrder = Mathf.Min(sm.state.storyOrder+1, 3);
        sm.Save();
        Debug.Log("AutoSeve");
    }
}