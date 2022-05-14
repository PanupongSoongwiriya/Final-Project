using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class YourTurn : MonoBehaviour
{


    [SerializeField]
    private bool move = false;
    public void stratMove()
    {
        gameObject.SetActive(true);
        Invoke("resetS", 1.5f);
    }
    private void resetS()
    {
        gameObject.SetActive(false);
        try
        {
            GameObject.Find("TutorialSystem").GetComponent<GameSystem>().GetComponent<TutorialSystem>().TutorialStep++;
        }
        catch (Exception e)
        {
        }
    }
}
