using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagDetailPanel : MonoBehaviour
{
    public int numberOfMedicine;
    public GameObject bagPanel_1;
    public GameObject bagPanel_2;
    public GameObject bagPanel_3;
    public GameSystem gameSystem;
    public bool activeBotton;

    void Update()
    {
        showDetail();
    }
    private void showDetail()
    {
        bagPanel_1.gameObject.SetActive(numberOfMedicine > 0);
        bagPanel_2.gameObject.SetActive(numberOfMedicine > 1);
        bagPanel_3.gameObject.SetActive(numberOfMedicine > 2);
        if (numberOfMedicine > 0)
        {
            GameObject.Find("Bag_1").GetComponentsInChildren<Text>()[0].text = gameSystem.NowCharecter.bag[0].statusName;
            GameObject.Find("Bag_1").GetComponentsInChildren<Text>()[1].text = ThaiFontAdjuster.Adjust(gameSystem.NowCharecter.bag[0].desCripTion);
        }
        if (numberOfMedicine > 1)
        {
            GameObject.Find("Bag_2").GetComponentsInChildren<Text>()[0].text = gameSystem.NowCharecter.bag[1].statusName;
            GameObject.Find("Bag_2").GetComponentsInChildren<Text>()[1].text = ThaiFontAdjuster.Adjust(gameSystem.NowCharecter.bag[1].desCripTion);
        }
        if (numberOfMedicine > 2)
        {
            GameObject.Find("Bag_3").GetComponentsInChildren<Text>()[0].text = gameSystem.NowCharecter.bag[2].statusName;
            GameObject.Find("Bag_3").GetComponentsInChildren<Text>()[1].text = ThaiFontAdjuster.Adjust(gameSystem.NowCharecter.bag[2].desCripTion);
        }
    }

    public void useMedicine()
    {
        Debug.Log("Use Medicine !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
    }
}
