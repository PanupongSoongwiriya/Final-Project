using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkwidt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform rt = GetComponent<RectTransform>();
        int width = Mathf.FloorToInt(rt.rect.width * Screen.width / 720);
        Debug.Log(name + ": " + width);
    }
}
