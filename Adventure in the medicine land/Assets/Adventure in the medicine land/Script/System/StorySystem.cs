using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class StorySystem : MonoBehaviour
{
    [SerializeField]
    private SaveManager sm;
    [SerializeField]
    private TextAsset jsonData;
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
    [SerializeField]
    private Image Background;
    [SerializeField]
    private Image Character_Left;
    [SerializeField]
    private Image Character_Right;

    [Serializable]
    public struct MyDictionary
    {
        public string name;
        public Sprite image;
        public Sprite image_Left;
        public Sprite image_Right;
    }
    [SerializeField]
    private MyDictionary[] CharacterSprite;
    [SerializeField]
    private MyDictionary[] BackgroundSprite;

    // Start is called before the first frame update
    void Start()
    {
        sm.Load();
        loadJson();
        index = 0;
        setDialog();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            setDialog();
        }*/
    }
    private void loadJson()
    {
        data = JsonUtility.FromJson<JsonData>(jsonData.text);
        for (int i = 0; i < data.story.Length; i++)
        {
            if (data.story[i].chapter == Mathf.Min(sm.state.storyOrder, 1))
            {
                chapter = data.story[i];
                break;
            }
        }
        /*chapter = data.story[0];*/
    }
    private void setDialog()
    {
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
            nameText.SetActive(!string.IsNullOrEmpty(dialog.actor));
            nameText.transform.GetChild(0).GetComponent<Text>().text = ThaiFontAdjuster.Adjust(dialog.actor);
            dialogText.transform.GetChild(0).GetComponent<Text>().text = ThaiFontAdjuster.Adjust(dialog.val);

            setCharacterImg(dialog.img_Left, Character_Left, "Left");
            setCharacterImg(dialog.img_Right, Character_Right, "Right");

            foreach (MyDictionary md in BackgroundSprite)
            {
                if (md.name.Equals(dialog.bg))
                {
                    Background.sprite = md.image;
                    break;
                }
            }

            /*Debug.Log("id: " + dialog.id);
            Debug.Log("actor: " + dialog.actor);
            Debug.Log("img_Left: " + dialog.img_Left);
            Debug.Log("img_Right: " + dialog.img_Right);
            Debug.Log("val: " + dialog.val);
            Debug.Log("sfx: " + dialog.sfx);
            Debug.Log("bg: " + dialog.bg);*/
        }
    }

    public void setCharacterImg(string imgText, Image img, string side)
    {
        img.color = new Color(1, 1, 1, 1);
        img.sprite = null;
        if (imgText == "")
        {
            img.color = new Color(1, 1, 1, 0);
        }
        else if (!imgText.Equals(dialog.actor))
        {
            img.color = new Color(0.5f, 0.5f, 0.5f, 1);
        }
        foreach (MyDictionary md in CharacterSprite)
        {
            if (md.name.Equals(imgText))
            {
                if (side.Equals("Right"))
                {
                    img.sprite = md.image_Right;
                }else if (side.Equals("Left"))
                {
                    img.sprite = md.image_Left;
                }
                break;
            }
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
    public int Index
    {
        get { return index; }
        set { index = value; setDialog(); }
    }
}
