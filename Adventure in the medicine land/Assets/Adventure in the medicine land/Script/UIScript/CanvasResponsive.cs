using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasResponsive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*Debug.Log("Screen Width : " + Screen.width);
        Debug.Log("Screen Height : " + Screen.height);
        Debug.Log("CanvasScaler X: " + GetComponent<CanvasScaler>().referenceResolution.x);
        Debug.Log("CanvasScaler Y: " + GetComponent<CanvasScaler>().referenceResolution.y);*/
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<CanvasScaler>().referenceResolution = new Vector2(Screen.width, GetComponent<CanvasScaler>().referenceResolution.y);
        //Debug.Log("Screen Width : " + Screen.width);
        //Debug.Log("Screen Height : " + Screen.height);
    }
}
