using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchArea : MonoBehaviour
{

    [SerializeField]
    private StorySystem ss;

    // Start is called before the first frame update
    void Start()
    {
        ss = GameObject.Find("StorySystem").GetComponent<StorySystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("gggggggggggggggggggggggggggggggggggggggggggggggggg");
            ss.Index++;
        }
    }
}
