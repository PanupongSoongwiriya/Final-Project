using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlPanelButton : MonoBehaviour
{

    public GameObject system;
    protected GameSystem gameSystem;
    public GameObject controlPanel;
    void Start()
    {
        gameSystem = system.GetComponent<GameSystem>();
    }

    public virtual void changeState()
    {
    }
}
