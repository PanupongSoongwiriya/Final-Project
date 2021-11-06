
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamageText : MonoBehaviour
{
    public int num;
    private float speed = 0.005f;
    public String type;
    void Start()
    {
        if (num >= 0)
        {
            GetComponent<TextMesh>().text = "+";
            GetComponent<TextMesh>().color = new Color(0, 1, 0, 1);
        }
        else
        {
            GetComponent<TextMesh>().text = "-";
            GetComponent<TextMesh>().color = new Color(1, 0, 0, 1);
        }

        num = Math.Abs(num);

        if (type.Equals("poison"))
        {
            GetComponent<TextMesh>().text += num;
            GetComponent<TextMesh>().color = new Color(0.5019608f, 0, 0.5019608f, 1);
        }
        else if (type.Equals("heal") || type.Equals("attack"))
        {
            GetComponent<TextMesh>().text += num;
        }
        else
        {
            GetComponent<TextMesh>().text += type;
        }

        Invoke("Destroy", 1f);
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z + speed);
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }

}
