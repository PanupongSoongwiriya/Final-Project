using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHeader : MonoBehaviour
{

    [SerializeField]
    private float idHeader;
    [SerializeField]
    private InformationBookSystem ibSystem;
    void Start()
    {
        ibSystem = GameObject.Find("InformationBookSystem").GetComponent<InformationBookSystem>();
    }

    public void setInfo()
    {
        ibSystem.NowData = idHeader;
    }
    public float IdHeader
    {
        get { return idHeader; }
        set { idHeader = value; }
    }
}
