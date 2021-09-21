using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamageText : MonoBehaviour
{
    public int dmg;
    private float speed = 0.005f;
    void Start()
    {
        GetComponent<TextMesh>().text = dmg+"";
        Invoke("Destroy", 1f);
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x-speed, transform.position.y, transform.position.z+speed);
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }

}
