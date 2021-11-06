using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class yourTurn : MonoBehaviour
{
    public float speed = 1.003f;
    private float y = 10;
    private Vector3 gameCamera;
    public float differenceX = 3;
    void Start()
    {
        Invoke("Destroy", 1.5f);
    }

    void Update()
    {
        gameCamera = GameObject.Find("Game Camera").transform.position;
        transform.position = new Vector3(gameCamera.x - differenceX, gameCamera.y-y, gameCamera.z);
        transform.localScale *= speed;
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
