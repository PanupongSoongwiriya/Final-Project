using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChannelMedicine : MonoBehaviour
{
    public BagDetailPanel bdp;
    [SerializeField]
    private Status medicine;
    [SerializeField]
    private bool select;
    [SerializeField]
    private bool activeChannel;
    [SerializeField]
    private float blackNess;
    [SerializeField]
    private AudioSource clickAudio;

    private void Start()
    {
        blackNess = 1;
        activeChannel = true;
    }

    public void OnClickThis()
    {
        if (medicine != null && activeChannel)
        {
            bdp.CM = this;
            clickAudio.Play();
        }
    }

    private void setColor(Color c)
    {
        transform.GetChild(0).GetComponent<Image>().color = c;
    }

    public Status Medicine
    {
        get { return medicine; }
        set
        {
            medicine = value;
            //set color here
            Image icon = transform.GetChild(0).GetComponent<Image>();
            icon.sprite = null;
            icon.color = new Color(1, 1, 1, 0);
            if (value != null)
            {
                icon.color = new Color(blackNess, blackNess, blackNess, 1);
                icon.sprite = value.icon_Medicine;
                if (!select)
                {
                    //setColor(Color.white);
                }
                else
                {
                    icon.sprite = value.icon_Medicine_Select;
                    //setColor(Color.yellow);
                }
            }
        }
    }
    public bool Select
    {
        get { return select; }
        set
        {
            select = value;
            //set color here
            setColor(Color.black);
            if (value)
            {
                Image icon = transform.GetChild(0).GetComponent<Image>();
                icon.sprite = medicine.icon_Medicine_Select;
                //setColor(Color.yellow);
            }
        }
    }
    public bool ActiveChannel
    {
        get { return activeChannel; }
        set
        {
            activeChannel = value;
            if (value)
            {
                blackNess = 1;
            }
            else
            {
                blackNess = 0.5f;
            }
        }
    }
}
