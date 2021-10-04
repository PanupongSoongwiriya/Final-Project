using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yourTurn : MonoBehaviour
{
    private float speed = 0.005f;
    private float y = 10;
    void Start()
    {
        Invoke("Destroy", 1.5f);
    }

    void Update()
    {
        transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y-y, Camera.main.transform.position.z);
        y -= speed;
    }
    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}
