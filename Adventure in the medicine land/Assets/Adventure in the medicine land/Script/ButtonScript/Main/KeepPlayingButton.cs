using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class KeepPlayingButton : MonoBehaviour
{
    public bool canChange = true;

    public void changeScene()
    {
        if (canChange)
        {
            SceneManager.LoadScene("Story Scene");
        }
    }

    public bool CanChange
    {
        get { return canChange; }
        set {
            canChange = value;
            float a = 1;
            if (!canChange)
            {
                a = 0.5f;
            }
            GetComponent<Image>().color = new Color(1, 1, 1, a);
        }
    }
}
