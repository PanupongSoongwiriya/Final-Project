using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class YourTurn : MonoBehaviour
{


    [SerializeField]
    private bool move = false;
    // Start is called before the first frame update
    void Start()
    {
        //transform.localScale = new Vector3(0.1f, 0.1f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (move)
        {
            float s = Math.Min(transform.localScale.x + 0.01f, 1.5f);
            transform.localScale = new Vector3(s, s, 1);
        }*/
    }
    public void stratMove()
    {
        //move = true;
        gameObject.SetActive(true);
        Invoke("resetS", 1.5f);
    }
    private void resetS()
    {
        /*transform.localScale = new Vector3(0.1f, 0.1f, 1);
        move = false;*/
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
