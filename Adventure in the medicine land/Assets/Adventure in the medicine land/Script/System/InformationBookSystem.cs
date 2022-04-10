using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class InformationBookSystem : MonoBehaviour
{
    [SerializeField]
    private TextAsset jsonData;
    [SerializeField]
    private BookData data;
    [SerializeField]
    private GameObject head;
    [SerializeField]
    private GameObject info;
    [SerializeField]
    private GameObject button;
    [SerializeField]
    private GameObject scrollHeader;
    [SerializeField]
    private GameObject dataContent;
    [SerializeField]
    private float nowData;

    [SerializeField]
    private Sprite[] buttonSprite;
    //[SerializeField]
    //private float distance;
    // Start is called before the first frame update
    void Start()
    {
        nowData = 1;
        loadJson();
    }
    private void loadJson()
    {
        data = JsonUtility.FromJson<BookData>(jsonData.text);

        float buttonHeight = button.GetComponent<RectTransform>().rect.height;

        //distance between 2 buttons
        float distance = (buttonHeight*(((Screen.width)*100)/1920)/100) * 1.3f;

        float scrollHeaderHeight;
        float scrollHeaderX = scrollHeader.transform.position.x;
        float scrollHeaderY;
        float scrollHeaderZ = scrollHeader.transform.position.z;

        //Create Button
        for (int i = 0; i < data.Book.Length; i++)
        {
            float buttonX = button.transform.position.x;
            float buttonY = button.transform.position.y + (i * -distance) ;
            float buttonZ = button.transform.position.z;
            GameObject newButton = Instantiate(button, new Vector3(buttonX, buttonY, buttonZ), transform.rotation);

            newButton.GetComponent<RectTransform>().sizeDelta = new Vector2(button.GetComponent<RectTransform>().rect.width, buttonHeight);

            foreach (Sprite b in buttonSprite)
            {
                if (b.name.Split(char.Parse("_")).Length == 2)
                {
                    if (float.Parse(b.name.Split(char.Parse("_"))[1]) - data.Book[i].id < 0.01)
                    {
                        newButton.GetComponent<Image>().sprite = b;
                    }
                }
                else if (b.name.Split(char.Parse("_")).Length == 3)
                {
                    if (float.Parse(b.name.Split(char.Parse("_"))[2]) - data.Book[i].id < 0.01)
                    {
                        SpriteState ss = newButton.GetComponent<Button>().spriteState;
                        ss.pressedSprite = b;
                        newButton.GetComponent<Button>().spriteState = ss;
                    }
                }
                
            }
            newButton.SetActive(true);
            newButton.transform.parent = scrollHeader.transform;
            newButton.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

            newButton.GetComponent<ButtonHeader>().IdHeader = data.Book[i].id;
            if (i == data.Book.Length - 1)
            {
                scrollHeaderHeight = -newButton.GetComponent<RectTransform>().anchoredPosition.y + buttonHeight + buttonHeight * 0.3f;
                scrollHeaderY = -scrollHeaderHeight / 2;
                scrollHeader.transform.position = new Vector3(scrollHeaderX, scrollHeaderY, scrollHeaderZ);
                scrollHeader.GetComponent<RectTransform>().sizeDelta = new Vector2(0, scrollHeaderHeight);
            }
        }
        setBookData();
    }

    public void setBookData()
    {
        for (int i = 0; i < data.Book.Length; i++)
        {
            if (data.Book[i].id == nowData)
            {
                /*Debug.Log("id: " + data.Book[i].id);
                Debug.Log("header: " + data.Book[i].header);
                Debug.Log("info: " + data.Book[i].info);
                Debug.Log("warning: " + data.Book[i].warning);
                Debug.Log("img: " + data.Book[i].img);*/
                string subID = "";
                if (data.Book[i].id.ToString().Split(char.Parse(".")).Length == 2)
                {
                    subID = " (" + data.Book[i].id.ToString().Split(char.Parse("."))[1] + ")";
                }
                head.GetComponent<Text>().text = ThaiFontAdjuster.Adjust(data.Book[i].header + subID);
                info.GetComponent<Text>().text = ThaiFontAdjuster.Adjust(data.Book[i].info + "\n<color=red>" + data.Book[i].warning + "</color>");
                RectTransform rt = dataContent.GetComponent<RectTransform>();
                float pc = ((Screen.width * 100f / 1244f))/100f;
                rt.sizeDelta = new Vector2(rt.sizeDelta.x, data.Book[i].heightContent * pc);
                Debug.Log("Screen Width : " + Screen.width);
                Debug.Log("Percent : " + pc + "%");
            }
        }
    }

    public float NowData
    {
        get { return nowData; }
        set { nowData = value; setBookData(); }
    }
}
