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
        ActiveBotton = false;
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
            description_Box.GetComponentsInChildren<Text>()[0].text = cm.medicine.statusName;
            description_Box.GetComponentsInChildren<Text>()[1].text = cm.medicine.desCripTion;
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
            bag.transform.GetChild(i).GetComponent<ChannelMedicine>().medicine = null;
        }
        for (int i = 0; i < gameSystem.NowCharecter.bag.Count; i++)
        {
            bag.transform.GetChild(i).GetComponent<ChannelMedicine>().medicine = gameSystem.NowCharecter.bag[i];
        }
    }

    public void useMedicine()
    {
        if (ActiveBotton)
        {
            ActiveBotton = false;
            Debug.Log("Use Medicine !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            gameSystem.selectedMedicine = CM.medicine;
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
            ActiveBotton = true;
            for (int i = 0; i < bag.transform.childCount; i++)
            {
                bag.transform.GetChild(i).GetComponent<ChannelMedicine>().Select = false;
            }
            value.Select = true;
        }
    }
    public bool ActiveBotton
    {
        get { return activeBotton; }
        set
        {
            activeBotton = value;
            float a = 0.5f;
            if (value)
            {
                a = 1;
            }
            useButton.GetComponent<Image>().color = new Color(1, 1, 1, a);
        }
    }
}
