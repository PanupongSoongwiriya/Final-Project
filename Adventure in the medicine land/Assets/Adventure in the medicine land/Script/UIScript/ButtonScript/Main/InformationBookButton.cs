using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InformationBookButton : MonoBehaviour
{
    public void changeScene()
    {
        Invoke("Change", 0.25f);
    }

    private void Change()
    {
        SceneManager.LoadScene("Information Book Scene");//Main Scene
    }
}
