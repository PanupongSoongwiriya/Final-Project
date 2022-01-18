using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChannelMedicine : MonoBehaviour, IPointerClickHandler
{
    public BagDetailPanel bdp;
    public Status medicine;
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
    public bool Select
    {
        get { return select; }
        set
        {
            select = value;
            //set color here
            GetComponent<Image>().color = Color.black;
            if (value)
            {
                GetComponent<Image>().color = Color.yellow;
            }
        }
    }
}
