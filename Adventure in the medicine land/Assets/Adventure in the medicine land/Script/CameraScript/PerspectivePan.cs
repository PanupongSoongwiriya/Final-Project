using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PerspectivePan : MonoBehaviour
{
    public GameSystem gameSystem;
    public float speed = 40;

    void Start()
    {
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && !gameSystem.State.Equals("round of bots"))
        {
            float x = Math.Max(-30, Math.Min(24, (Input.GetAxisRaw("Mouse Y")) + transform.position.x));
            float z = Math.Max(6, Math.Min(60, -(Input.GetAxisRaw("Mouse X")) + transform.position.z));
            transform.position = new Vector3(x, transform.position.y, z);
        }
    }
}
