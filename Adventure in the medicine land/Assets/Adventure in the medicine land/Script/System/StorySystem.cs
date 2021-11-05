using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StorySystem : MonoBehaviour
{
    [SerializeField]
    private SaveManager sm;
    [SerializeField]
    private string jsonPath;
    [SerializeField]
    private JsonData data;
    [SerializeField]
    private Chapter chapter;
    [SerializeField]
    private dialog dialog;
    [SerializeField]
    private int index;
    [SerializeField]
    private GameObject nameText;
    [SerializeField]
    private GameObject dialogText;
    // Start is called before the first frame update
    void Start()
    {
        sm.Load();
        loadJson();
        index = -1;
        setDialog();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            setDialog();
        }
    }
    private void loadJson()
    {
        using (StreamReader stream = new StreamReader(jsonPath))
        {
            string json = stream.ReadToEnd();
            Debug.Log(json);
            data = JsonUtility.FromJson<JsonData>(json);
            int test = Mathf.Min(sm.state.storyOrder, 1);
            for (int i = 0; i < data.story.Length; i++)
            {
                if (data.story[i].chapter == test)
                {
                    chapter = data.story[i];
                    break;
                }
            }
            /*Debug.Log(data);
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
            }*/
        }
    }
    private void setDialog()
    {
        ++index;
        for (int i = 0; i < chapter.dialog.Length; i++)
        {
            if (chapter.dialog[i].id == index)
            {
                dialog = chapter.dialog[i];
                break;
            }
        }
        if (index == chapter.dialog.Length)
        {
            changeScene();
        }
        else
        {
            nameText.transform.GetChild(0).GetComponent<Text>().text = ThaiFontAdjuster.Adjust(dialog.actor);
            dialogText.transform.GetChild(0).GetComponent<Text>().text = ThaiFontAdjuster.Adjust(dialog.val);
            Debug.Log("id: " + dialog.id);
            Debug.Log("actor: " + dialog.actor);
            Debug.Log("val: " + dialog.val);
            Debug.Log("sfx: " + dialog.sfx);
        }
    }
    public void changeScene()
    {
        if (sm.state.storyOrder != -1)
        {
            SceneManager.LoadScene("Game Scene");
        }
        else
        {
            SceneManager.LoadScene("Tutorial Scense");
        }
    }
}
