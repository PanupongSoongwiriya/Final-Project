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
    public bool select;
    [SerializeField]
    private AudioSource clickAudio;

    public void OnClickThis()
    {
        if (medicine != null)
        {
            bdp.CM = this;
            clickAudio.Play();
        }
    }

    private void setColor(Color c)
    {
        GetComponent<Image>().color = c;
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
                icon.color = new Color(1, 1, 1, 1);
                icon.sprite = value.icon_Medicine;
                if (!select)
                {
                    setColor(Color.white);
                }
                else
                {
                    setColor(Color.yellow);
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
            //setColor(Color.black);
            if (value)
            {
                setColor(Color.yellow);
            }
        }
    }
}
