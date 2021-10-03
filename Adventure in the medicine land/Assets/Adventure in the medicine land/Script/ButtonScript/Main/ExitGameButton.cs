using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameButton : MonoBehaviour
{
    public void exit()
    {
        //if UNITY_EDITOR
        /*if (Application.platform == RuntimePlatform.WindowsPlayer || Application.isEditor) { 
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {*/
            //endif
            Application.Quit();
        //}
    }
}
