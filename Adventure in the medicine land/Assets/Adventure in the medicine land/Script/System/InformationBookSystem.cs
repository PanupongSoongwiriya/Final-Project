using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InformationBookSystem : MonoBehaviour
{
    [SerializeField]
    private string jsonPath;
    [SerializeField]
    private BookData data;
    [SerializeField]
    private int idBook;
    // Start is called before the first frame update
    void Start()
    {
        loadJson();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void loadJson()
    {
        using (StreamReader stream = new StreamReader(jsonPath))
        {
            string json = stream.ReadToEnd();
            Debug.Log(json);
            data = JsonUtility.FromJson<BookData>(json);
            for (int i = 0; i < data.Book.Length; i++)
            {
                Debug.Log("id: " + data.Book[i].id);
                Debug.Log("header: " + data.Book[i].header);
                Debug.Log("info: " + data.Book[i].info);
                Debug.Log("warning: " + data.Book[i].warning);
                Debug.Log("img: " + data.Book[i].img);
            }
        }
    }
}
