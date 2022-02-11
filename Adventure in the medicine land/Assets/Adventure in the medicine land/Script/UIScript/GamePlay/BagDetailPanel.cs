using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagDetailPanel : MonoBehaviour
{
    public GameObject bag;
    public GameObject description_Box;
    public GameObject useButton;
    public ChannelMedicine cm;
    public GameSystem gameSystem;
    public controlPanelButton cpb;
    public bool activeBotton;

    void Start()
    {
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
        for (int i = 0; i < bag.transform.childCount; i++)
        {
            bag.transform.GetChild(i).GetComponent<ChannelMedicine>().bdp = this;
            bag.transform.GetChild(i).GetComponent<ChannelMedicine>().Medicine = null;
        }
        for (int i = 0; i < gameSystem.NowCharecter.bag.Count; i++)
        {
            bag.transform.GetChild(i).GetComponent<ChannelMedicine>().Medicine = gameSystem.NowCharecter.bag[i];
        }
    }

    public void showPanel()
    {
        cm = null;
        ActiveBotton = false;
        for (int i = 0; i < bag.transform.childCount; i++)
        {
            bag.transform.GetChild(i).GetComponent<ChannelMedicine>().Select = false;
        }
    }

    public void useMedicine()
    {
        if (ActiveBotton)
        {
            ActiveBotton = false;
            gameSystem.selectedMedicine = CM.Medicine;
            gameSystem.State = "Use medicine with ally";
            useButton.SetActive(false);
            cm = null;
            for (int i = 0; i < bag.transform.childCount; i++)
            {
                bag.transform.GetChild(i).GetComponent<ChannelMedicine>().Select = false;
            }
            cpb.switchPanel(true, false, false, false, false);//controlPanel, optionsPanel, skillPanel, characterDetailPanel, skillDetailPanel
        }
    }
    public ChannelMedicine CM
    {
        get { return cm; }
        set
        {
            cm = value;
            for (int i = 0; i < bag.transform.childCount; i++)
            {
                bag.transform.GetChild(i).GetComponent<ChannelMedicine>().Select = false;
            }
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
