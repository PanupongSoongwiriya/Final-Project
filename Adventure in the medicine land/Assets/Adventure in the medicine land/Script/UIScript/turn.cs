using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turn : MonoBehaviour
{
    Text txt;
    protected GameSystem gameSystem;
    void Start()
    {
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        txt = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        txt.text = ThaiFontAdjuster.Adjust("เทิร์น: " + gameSystem.Turn);
    }
}
