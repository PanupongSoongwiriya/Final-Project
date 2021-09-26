using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PerspectivePan : MonoBehaviour
{
    private Vector3 touchStart;
    public Camera cam;
    public float groundZ;
    private Vector3 beforeMousePosition;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            if (beforeMousePosition != Input.mousePosition)
            {
                beforeMousePosition = Input.mousePosition;
                Vector3 direction = -((touchStart - Input.mousePosition)/500);

                float x = Math.Max(-30, Math.Min(24, Camera.main.transform.position.x + direction.y));
                float zzz = Math.Max(6, Math.Min(60, Camera.main.transform.position.z + -direction.x));
                Camera.main.transform.position = new Vector3(x, 35, zzz);
            }
            else
            {
                touchStart = Input.mousePosition;
            }
        }
    }
    private Vector3 GetWorldPosition(float z)
    {
        Ray mousePos = cam.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.forward, new Vector3(0, z, 0));
        float distane;
        ground.Raycast(mousePos, out distane);
        return mousePos.GetPoint(-distane);
    }
}
