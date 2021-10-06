using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PerspectivePan : MonoBehaviour
{
    public GameSystem gameSystem;
    public float speed = 30;
    public CameraFollow cf;
    public float minX = -20;
    public float maxX = 34;
    public float minZ = 6;
    public float maxZ = 60;

    void Start()
    {
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
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
}
