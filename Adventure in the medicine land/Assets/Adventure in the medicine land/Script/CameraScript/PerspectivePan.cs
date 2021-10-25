using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PerspectivePan : MonoBehaviour
{
    public GameSystem gameSystem;
    public CameraFollow cf;
    public float speed = 25;
    public int numWidth;//num of all channel in image width
    public float minX = 40;
    public float maxX = 34;
    public float minZ = 6;
    public float maxZ = 0;

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
        cf = gameObject.GetComponent<CameraFollow>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && !gameSystem.lockCamera && !cf.changTarget && !gameSystem.endGame)
        {
            float x = Math.Max(minX, Math.Min(maxX, (Input.GetAxisRaw("Mouse Y")) + transform.position.x));
            float z = Math.Max(minZ, Math.Min(maxZ, -(Input.GetAxisRaw("Mouse X")) + transform.position.z));
            transform.position = new Vector3(x, transform.position.y, z);
        }
    }

    public int NumWidth
    {
        get { return numWidth; }
        set { numWidth = value;
            minX = 40 - (numWidth * 6);
            maxZ = numWidth * 6;
            Vector3 centerStagePoint = new Vector3(37 - (numWidth * 3), transform.position.y, 3 + (numWidth * 3));
            transform.position = centerStagePoint;
            gameSystem.transform.position = centerStagePoint;
        }
    }
}
