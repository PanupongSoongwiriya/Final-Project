using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameButton : MonoBehaviour
{
    public void exit()
    {
        Invoke("Change", 0.25f);
    }
    private void Change()
    {
        Application.Quit();
    }
}
