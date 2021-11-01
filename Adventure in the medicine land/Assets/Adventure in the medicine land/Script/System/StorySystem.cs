using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorySystem : MonoBehaviour
{
    public SaveManager sm;
    // Start is called before the first frame update
    void Start()
    {
        sm.Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
