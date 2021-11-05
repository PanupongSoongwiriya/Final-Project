using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CGetJson : MonoBehaviour
{
    public string storyPath;
    // Start is called before the first frame update
    void Start()
    {
        using (StreamReader stream = new StreamReader(storyPath))
        {
            string json = stream.ReadToEnd();
            Debug.Log(json);
            CRoot root = JsonUtility.FromJson<CRoot>(json);
            Debug.Log(root);
            Debug.Log(root.events);
            Debug.Log(root.events.Length);
            Debug.Log(root.events[0].name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
