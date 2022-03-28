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
    public GameObject characterDetailPanel;
    public GameObject bagDetailPanel;
    public GameObject sheatheMenu;
    public GameObject sheatheData;
    public bool activeBotton;
    public float c = 1;
    [SerializeField]
    protected AudioSource ConfirmAudio;
    [SerializeField]
    protected AudioSource CancelAudio;
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
        characterDetailPanel.gameObject.SetActive(cdp);
        bagDetailPanel.gameObject.SetActive(sp);
        optionsPanel.gameObject.SetActive(op);
        controlPanel.gameObject.SetActive(cp);
    }

    protected void active()
    {
        c = 0.5f;
        if (activeBotton)
        {
            c = 1;
        }
        GetComponent<Image>().color = new Color(c, c, c, 1);        
    }

    public bool ActiveBotton
    {
        get { return activeBotton; }
        set { activeBotton = value; active(); }
    }
}
