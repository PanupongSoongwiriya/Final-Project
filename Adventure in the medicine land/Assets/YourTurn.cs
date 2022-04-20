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
        //move = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            Debug.Log("3333333333333333333333333333333333333333333");
            transform.localPosition = new Vector3(0, 0, Math.Max(transform.localPosition.z-85, -300));
        }
    }
    public void stratMove()
    {
        Debug.Log("11111111111111111111111111111111111111111111111111111");
        move = true;
        gameObject.SetActive(true);
        Debug.Log("22222222222222222222222222222222222" + move);
        Invoke("resetZ", 1.5f);
    }
    private void resetZ()
    {
        try
        {
            GameObject.Find("TutorialSystem").GetComponent<GameSystem>().GetComponent<TutorialSystem>().TutorialStep++;
        }
        catch (Exception e)
        {
        }
        Debug.Log("44444444444444444444444444444444444444444444444");
        transform.localPosition = new Vector3(0, 0, 10000);
        move = false;
        gameObject.SetActive(false);
    }
}
