using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class InformationBookSystem : MonoBehaviour
{
    [SerializeField]
    private string jsonPath;
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
    private float nowData; 
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
        float distance = buttonHeight / 2 + (buttonHeight * 0.3f);

        float scrollHeaderHeight;
        float scrollHeaderX = scrollHeader.transform.position.x;
        float scrollHeaderY;
        float scrollHeaderZ = scrollHeader.transform.position.z;

        //Create Button
        for (int i = 0; i < data.Book.Length; i++)
        {
            float buttonX = button.transform.position.x;
            float buttonY = button.transform.position.y + (i * -distance);
            float buttonZ = button.transform.position.z;
            GameObject newButton = Instantiate(button, new Vector3(buttonX, buttonY, buttonZ), transform.rotation);

            newButton.GetComponent<RectTransform>().sizeDelta = new Vector2(button.GetComponent<RectTransform>().rect.width, buttonHeight);

            string subID = "";
            if (data.Book[i].id.ToString().Split(char.Parse(".")).Length == 2)
            {
                subID = " (" + data.Book[i].id.ToString().Split(char.Parse("."))[1] + ")";
            }
            newButton.transform.GetChild(0).GetComponent<Text>().text = data.Book[i].header + subID;
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
        /*using (StreamReader stream = new StreamReader(jsonPath))
        {
            string json = stream.ReadToEnd();
            //Debug.Log(json);
            //data = JsonUtility.FromJson<BookData>(json);
            data = JsonUtility.FromJson<BookData>(jsonData.text);

            float buttonHeight = button.GetComponent<RectTransform>().rect.height;

            //distance between 2 buttons
            float distance = buttonHeight / 2 + (buttonHeight * 0.3f);

            float scrollHeaderHeight;
            float scrollHeaderX = scrollHeader.transform.position.x;
            float scrollHeaderY;
            float scrollHeaderZ = scrollHeader.transform.position.z;


            for (int i = 0; i < data.Book.Length; i++)
            {
                float buttonX = button.transform.position.x;
                float buttonY = button.transform.position.y + (i * -distance);
                float buttonZ = button.transform.position.z;
                GameObject newButton = Instantiate(button, new Vector3(buttonX, buttonY, buttonZ), transform.rotation);

                newButton.GetComponent<RectTransform>().sizeDelta = new Vector2(button.GetComponent<RectTransform>().rect.width, buttonHeight);

                string subID = "";
                if (data.Book[i].id.ToString().Split(char.Parse(".")).Length == 2)
                {
                    subID = " (" + data.Book[i].id.ToString().Split(char.Parse("."))[1] + ")";
                }
                newButton.transform.GetChild(0).GetComponent<Text>().text = data.Book[i].header + subID;
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
        }*/
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
            }
        }
    }

    public float NowData
    {
        get { return nowData; }
        set { nowData = value; setBookData(); }
    }
}
