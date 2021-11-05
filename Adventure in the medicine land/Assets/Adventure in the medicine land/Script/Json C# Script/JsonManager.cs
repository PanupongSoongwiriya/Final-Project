using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonManager : MonoBehaviour
{
    public string jsonPath;
    void Start()
    {
        using (StreamReader stream = new StreamReader(jsonPath))
        {
            string json = stream.ReadToEnd();
            Debug.Log(json);
            JsonData data = JsonUtility.FromJson<JsonData>(json);
            Debug.Log(data);
            Debug.Log(data.story);
            Debug.Log(data.story.Length);
            for (int i = 0; i < data.story.Length; i++)
            {
                Debug.Log("chapter: " + data.story[i].chapter);
                Debug.Log("dialog: " + data.story[i].dialog);
                Debug.Log("dialog.Length: " + data.story[i].dialog.Length);
                for (int j = 0; j < data.story.Length; j++)
                {
                    Debug.Log("id: " + data.story[i].dialog[j].id);
                    Debug.Log("actor: " + data.story[i].dialog[j].actor);
                    Debug.Log("val: " + data.story[i].dialog[j].val);
                    Debug.Log("sfx: " + data.story[i].dialog[j].sfx);
                }
            }
        }
    }
}
