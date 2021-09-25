using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.3f;

    public bool changTarget = false;

    void FixedUpdate()
    {
        if (changTarget)
        {
            if (target == null)
            {
                changTarget = false;
            }
            Vector3 desiredPosition = target.position;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = new Vector3(smoothedPosition.x, Camera.main.transform.position.y, smoothedPosition.z);
            bool equalsX = 0.1 > Math.Abs(transform.position.x - target.position.x);
            bool equalsZ = 0.1 > Math.Abs(transform.position.z - target.position.z);
            if (equalsX && equalsZ)
            {
                changTarget = false;
            }
        }
    }

    public Transform Target
    {
        get { return target; }
        set { target = value; changTarget = true; }
    }
}
