using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlPanelButton : MonoBehaviour
{

    public GameObject system;
    protected GameSystem gameSystem;
    public GameObject controlPanel;
    public GameObject optionsPanel;
    public GameObject skillPanel;
    public GameObject characterDetailPanel;
    public GameObject skillDetailPanel;
    void Start()
    {
        gameSystem = system.GetComponent<GameSystem>();
    }

    public virtual void changeState()
    {
    }
    public void switchPanel(bool cp, bool op, bool sp, bool cdp, bool sdp)
    {
        controlPanel.gameObject.SetActive(cp);
        optionsPanel.gameObject.SetActive(op);
        skillPanel.gameObject.SetActive(sp);
        characterDetailPanel.gameObject.SetActive(cdp);
        skillDetailPanel.gameObject.SetActive(sdp);
    }
}
