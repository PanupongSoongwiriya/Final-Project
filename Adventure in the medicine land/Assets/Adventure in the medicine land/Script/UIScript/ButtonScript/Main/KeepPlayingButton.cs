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
            Invoke("Change", 0.25f);
        }
    }

    private void Change()
    {
        SceneManager.LoadScene("Story Scene");
    }

public bool CanChange
    {
        get { return canChange; }
        set {
            canChange = value;
            float c = 1;
            if (!canChange)
            {
                c = 0.5f;
            }
            GetComponent<Image>().color = new Color(c, c, c, 1);
        }
    }
}
