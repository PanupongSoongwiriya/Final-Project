using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamageText : MonoBehaviour
{
    public int dmg;
    private float speed = 0.005f;
    public String typeDMG;
    void Start()
    {
        GetComponent<TextMesh>().text = dmg+"";
        if(typeDMG.Equals("floor")) {
            GetComponent<TextMesh>().color = new Color(0.5019608f, 0f, 0.5019608f, 1f);
        }
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
