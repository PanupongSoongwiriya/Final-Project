using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BagDetailPanel : MonoBehaviour
{
    public GameObject bag;
    public GameObject description_Box;
    public GameObject useButton;
    public ChannelMedicine cm;
    public GameSystem gameSystem;
    public controlPanelButton cpb;
    public bool activeBotton;
    [SerializeField]
    private AudioSource ConfirmAudio;
    [SerializeField]
    private List<ChannelMedicine> CM_List;

    void Start()
    {
        try
        {
            gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        }
        catch (Exception e)
        {
            gameSystem = GameObject.Find("TutorialSystem").GetComponent<GameSystem>();
        }
    }

    void Update()
    {
        setBag();
        showDetail();
    }
    private void showDetail()
    {
        if (cm != null)
        {
            description_Box.GetComponentsInChildren<Text>()[0].text = cm.Medicine.statusName;
            description_Box.GetComponentsInChildren<Text>()[1].text = cm.Medicine.desCripTion;
        }
        else
        {
            description_Box.GetComponentsInChildren<Text>()[0].text = "";
            description_Box.GetComponentsInChildren<Text>()[1].text = "";
        }
    }
    private void setBag()
    {
        foreach (ChannelMedicine cm in CM_List)
        {
            cm.bdp = this;
            cm.Medicine = null;
        }
        /*for (int i = 9; i < bag.transform.childCount; i++)
        {
            ChannelMedicine cm = bag.transform.GetChild(i).GetComponent<ChannelMedicine>();
            cm.bdp = this;
            cm.Medicine = null;
        }*/
        for (int i = 0; i < gameSystem.NowCharecter.bag.Count; i++)
        {
            CM_List[i].Medicine = gameSystem.NowCharecter.bag[i];
            //bag.transform.GetChild(i+9).GetComponent<ChannelMedicine>().Medicine = gameSystem.NowCharecter.bag[i];
        }
    }

    public void setActiveChannel(int index)
    {
        for (int i = 0; i < CM_List.Count; i++)
        {
            CM_List[i].ActiveChannel = false;
            if (i == index)
            {
                CM_List[i].ActiveChannel = true;
            }
        }
    }

    public void showPanel()
    {
        cm = null;
        ActiveBotton = false;
        setSelectFalse();
    }

    public void useMedicine()
    {
        if (ActiveBotton)
        {
            tutorialPlus();
            ConfirmAudio.Play();
            ActiveBotton = false;
            gameSystem.selectedMedicine = CM.Medicine;
            gameSystem.State = "Use medicine with ally";
            useButton.SetActive(false);
            cm = null;
            setSelectFalse();
            cpb.switchPanel(true, false, false, false, false);//controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
        }
    }
    private void tutorialPlus()
    {
        if (gameSystem.name.Equals("TutorialSystem"))
        {
            gameSystem.GetComponent<TutorialSystem>().TutorialStep++;
        }
    }

    public void setSelectFalse()
    {
        foreach (ChannelMedicine cm in CM_List)
        {
            cm.Select = false;
        }
    }
    public ChannelMedicine CM
    {
        get { return cm; }
        set
        {
            cm = value;
            setSelectFalse();
            if (value != null)
            {
                ActiveBotton = true;
                value.Select = true;
            }
        }
    }
    public bool ActiveBotton
    {
        get { return activeBotton; }
        set
        {
            activeBotton = value;
            float c = 0.5f;
            if (value)
            {
                c = 1;
            }
            useButton.GetComponent<Image>().color = new Color(c, c, c, 1);
        }
    }
}
