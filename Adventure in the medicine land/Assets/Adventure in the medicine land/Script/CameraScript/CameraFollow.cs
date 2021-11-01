using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour
{
    public GameSystem gameSystem;

    public Transform target;

    public float smoothSpeed = 0.1f;

    public bool changTarget = false;

    public float differenceX = 10;

    void Start()
    {
        try
        {
            gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        }
        catch (Exception e)
        {
            gameSystem = GameObject.Find("TutorialSystem").GetComponent<GameSystem>();
        }
    }
    void FixedUpdate()
    {
        if (changTarget)
        {
            if (target == null)
            {
                changTarget = false;
            }
            Vector3 desiredPosition = new Vector3(target.position.x + differenceX, target.position.y, target.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = new Vector3(smoothedPosition.x, Camera.main.transform.position.y, smoothedPosition.z);
            bool equalsX = 0.1 > Math.Abs(transform.position.x - (target.position.x + differenceX));
            bool equalsZ = 0.1 > Math.Abs(transform.position.z - target.position.z);
            if (equalsX && equalsZ || (Input.GetMouseButtonDown(0)) && !gameSystem.lockCamera)
            {
                changTarget = false;
                if (gameSystem.NowCharecter != null)
                {
                    //When the camera arrives, Bot it works.
                    if (gameSystem.NowCharecter.botDisease != null & gameSystem.State.Equals("round of bots"))
                    {
                        gameSystem.NowCharecter.botDisease.botWork();
                    }
                }
            }
        }
    }

    public Transform Target
    {
        get { return target; }
        set { target = value; changTarget = true; }
    }
}
