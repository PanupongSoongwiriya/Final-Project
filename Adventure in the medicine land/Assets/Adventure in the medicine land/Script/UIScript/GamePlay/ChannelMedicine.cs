using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChannelMedicine : MonoBehaviour, IPointerClickHandler
{
    public BagDetailPanel bdp;
    [SerializeField]
    private Status medicine;
    public bool select;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (medicine != null)
        {
            bdp.CM = this;
            Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
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
            GetComponent<Image>().color = Color.black;
            if (value != null)
            {
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
            setColor(Color.black);
            if (value)
            {
                setColor(Color.yellow);
            }
        }
    }
}
