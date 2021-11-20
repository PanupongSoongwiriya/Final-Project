using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class yourTurn : MonoBehaviour
{
    [SerializeField]
    private float y = 10;
    [SerializeField]
    private Vector3 gameCamera;
    [SerializeField]
    private float differenceX = 3;
    void Start()
    {
        Invoke("Destroy", 1.5f);
    }

    void Update()
    {
        gameCamera = GameObject.Find("Game Camera").transform.position;
        transform.position = new Vector3(gameCamera.x - differenceX, gameCamera.y-y, gameCamera.z);
    }
    private void Destroy()
    {
        try
        {
            GameObject.Find("TutorialSystem").GetComponent<GameSystem>().GetComponent<TutorialSystem>().TutorialStep++;
        }
        catch (Exception e)
        {
        }
        Destroy(this.gameObject);
    }
}
