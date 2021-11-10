using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class controlPanelButton : MonoBehaviour
{
    protected GameSystem gameSystem;
    public GameObject controlPanel;
    public GameObject optionsPanel;
    public GameObject skillPanel;
    public GameObject characterDetailPanel;
    public GameObject skillDetailPanel;
    public GameObject sheatheMenu;
    public GameObject sheatheData;
    public bool activeBotton;
    public float alpha = 1;
    void Start()
    {
        activeBotton = true;
        try
        {
            gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        }
        catch (Exception e)
        {
            gameSystem = GameObject.Find("TutorialSystem").GetComponent<GameSystem>();
        }
        sheatheMenu = GameObject.Find("Game Camera").transform.GetChild(1).gameObject;
        sheatheData = GameObject.Find("Game Camera").transform.GetChild(2).gameObject;
    }

    public virtual void changeState()
    {
    }

    protected void tutorialPlus()
    {
        if (gameSystem.name.Equals("TutorialSystem"))
        {
            gameSystem.GetComponent<TutorialSystem>().TutorialStep++;
        }
    }
    public void switchPanel(bool cp, bool op, bool sp, bool cdp, bool sdp)
    {
        sheatheMenu.gameObject.SetActive(cp);
        sheatheData.gameObject.SetActive(cdp || sdp);
        skillDetailPanel.gameObject.SetActive(sdp);
        characterDetailPanel.gameObject.SetActive(cdp);
        skillPanel.gameObject.SetActive(sp);
        optionsPanel.gameObject.SetActive(op);
        controlPanel.gameObject.SetActive(cp);
    }

    protected void active()
    {
        alpha = 0.25f;
        if (activeBotton)
        {
            alpha = 1;
        }
        GetComponent<Image>().color = new Color(1, 1, 1, alpha);        
    }

    public bool ActiveBotton
    {
        get { return activeBotton; }
        set { activeBotton = value; active(); }
    }
}
