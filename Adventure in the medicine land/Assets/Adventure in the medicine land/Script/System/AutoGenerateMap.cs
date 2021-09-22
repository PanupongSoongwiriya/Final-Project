using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class AutoGenerateMap : MonoBehaviour
{
    public Texture2D image;
    Dictionary<string, Color> typeColor = new Dictionary<string, Color>();

    private GameSystem gameSystem;

    public int phase = 90;//width of one channel
    public int scaleFloor = 6;
    private int start_x;//half of phase
    private int start_y;//half of phase
    public int bonusFloor = 1;

    public GameObject floorModel;
    public GameObject lineModel;
    private GameObject floorObject;

    void Start()
    {
        start_x = phase / 2;
        start_y = phase / 2;
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        setColor();
        readMapImage();
        // x = Left(-), Right(+)
        // y = Front(+), Back(-)
        // createFloor(0, 0);

    }

    void Update()
    {

    }
    private void setColor()
    {
        typeColor.Add("black", Color.black);//Free Space
        typeColor.Add("white", Color.white);//Normal
        typeColor.Add("red", Color.red);//+ATK
        typeColor.Add("cyan", Color.cyan);//-ATK
        typeColor.Add("gray", new Color(0.5019608f, 0.5019608f, 0.5019608f, 1f));//+DEF
        typeColor.Add("brown", new Color(0.6470588f, 0.1647059f, 0.1647059f, 1f));//-DEF
        typeColor.Add("purple", new Color(0.5019608f, 0f, 0.5019608f, 1f));//Poison
    }
    private void readMapImage()
    {
        bool horizontalLine = true;
        int count_id = 1;

        //Generate Vertical Line
        Instantiate(lineModel, new Vector3(-3, 0, 3), transform.rotation).transform.localScale = new Vector3(((image.width / phase) * scaleFloor), 0.2f, 0.2f);

        //Generate Horizontal Line
        Instantiate(lineModel, new Vector3(((image.width / phase) * 3) - 3, 0, ((image.height / phase) * 3) + 3), transform.rotation).transform.localScale = new Vector3(0.2f, 0.2f, ((image.height / phase) * scaleFloor));

        for (int x = 0; x < image.width; x += phase)
        {

            //Generate Vertical Line
            Instantiate(lineModel, new Vector3(-3, 0, (((x + phase) / phase) * scaleFloor) + 3), transform.rotation).transform.localScale = new Vector3(((image.width / phase) * scaleFloor), 0.2f, 0.2f);
            //Generate Vertical Line

            for (int y = 0; y < image.height; y += phase)
            {
                Color pixFloor = image.GetPixel((start_x + x), (start_y + y));
                if (!pixFloor.gamma.Equals(typeColor["black"].gamma))
                {
                    int floor_x = scaleFloor * (((start_y + y - (phase / 2)) / phase) - 4);
                    int floor_z = scaleFloor * ((start_x + x + (phase / 2)) / phase);
                    if (floor_x > 0)
                    {
                        floor_x = -floor_x;
                    }
                    else
                    {
                        floor_x = Math.Abs(floor_x);
                    }
                    generateFloor(floor_x, floor_z, pixFloor, count_id);
                    count_id++;
                }
                //Generate Horizontal Line
                if (horizontalLine)
                {
                    Instantiate(lineModel, new Vector3(((image.width / phase) * (scaleFloor / 2)) - 3 - (scaleFloor * ((y + phase) / phase)), 0, ((image.height / phase) * (scaleFloor / 2)) + 3), transform.rotation).transform.localScale = new Vector3(0.2f, 0.2f, ((image.height / phase) * scaleFloor));
                }
            }
            horizontalLine = false;
        }
    }
    private void generateFloor(int x_Coordinate, int z_Coordinate, Color pixFloor, int id)
    {
        floorObject = Instantiate(floorModel, new Vector3(x_Coordinate, 0, z_Coordinate), transform.rotation);
        floorObject.name = "floor " + id;
        gameSystem.allFloor.Add(floorObject);
        if (pixFloor.gamma.Equals(typeColor["white"].gamma))//Normal
        {
            floorObject.AddComponent<Floor>();
        }
        else if (pixFloor.gamma.Equals(typeColor["red"].gamma))//+ATK
        {
            floorObject.AddComponent<floorATK>().SA = bonusFloor;
        }
        else if (pixFloor.gamma.Equals(typeColor["cyan"].gamma))//-ATK
        {
            floorObject.AddComponent<floorATK>().SA = -bonusFloor;
        }
        else if (pixFloor.gamma.Equals(typeColor["gray"].gamma))//+DEF
        {
            floorObject.AddComponent<floorDEF>().SD = bonusFloor;
        }
        else if (pixFloor.gamma.Equals(typeColor["brown"].gamma))//-DEF
        {
            floorObject.AddComponent<floorDEF>().SD = -bonusFloor;
        }
        else if (pixFloor.gamma.Equals(typeColor["purple"].gamma))//Poison
        {
            floorObject.AddComponent<floorPoison>();
        }
    }


}
