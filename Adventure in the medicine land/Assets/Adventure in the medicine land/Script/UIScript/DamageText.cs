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
        if (dmg >= 0)
        {
            GetComponent<TextMesh>().text = "+"+dmg;
        }
        else
        {
            GetComponent<TextMesh>().text = "" + dmg;
        }
        if(typeDMG.Equals("poison")) {
            GetComponent<TextMesh>().color = new Color(0.5019608f, 0f, 0.5019608f, 1f);
        }else if (typeDMG.Equals("heal"))
        {
            GetComponent<TextMesh>().color = new Color(0, 1, 0, 1f);
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
