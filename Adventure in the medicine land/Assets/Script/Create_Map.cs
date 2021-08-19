using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Create_Map : MonoBehaviour
{
    public GameObject floorModel;

    private GameObject floorObject;

    public Texture2D image;
    Dictionary<string, Color> typeColor = new Dictionary<string, Color>();

    void Start()
    {
        setColor();
        readMap();
        // x = Left(-), Right(+)
        // y = Front(+), Back(-)
        // createFloor(0, 0);

    }

    void Update()
    {

    }
    private void setColor()
    {
        typeColor.Add("white", Color.white);//Free Space
        typeColor.Add("red", Color.red);//Can't walk
        typeColor.Add("brown", new Color(0.6470588f, 0.1647059f, 0.1647059f, 1.000f));//
        typeColor.Add("gray", new Color(0.5019608f, 0.5019608f, 0.5019608f, 1f));//Normal Floor
    }
    private void readMap()
    {
        int start_x = 45;
        int start_y = 45;
        for (int x = 0; x < image.width; x += 90)
        {
            for (int y = 0; y < image.height; y += 90)
            {
                Color pixFloor = image.GetPixel((start_x + x), (start_y + y));
                //Debug.Log(pixFloor);
                //Debug.Log(pixFloor.Equals(Color.red));
                if (!pixFloor.gamma.Equals(typeColor["white"].gamma))
                {
                    int floor_x = 6 * (((start_y + y - 45) / 90) - 4);
                    int floor_y = 6 * ((start_x + x + 45) / 90);
                    if (floor_x > 0)
                    {
                        floor_x = -floor_x;
                    }
                    else
                    {
                        floor_x = Math.Abs(floor_x);
                    }
                    createFloor(floor_x, floor_y, pixFloor);
                }
            }
        }
    }
    private void createFloor(float x_Coordinate, float z_Coordinate, Color pixFloor)
    {
        floorObject = Instantiate(floorModel, new Vector3(x_Coordinate, 0, z_Coordinate), transform.rotation);
        floorObject.AddComponent<BoxCollider>();
        floorObject.GetComponent<Renderer>().material.SetColor("_Color", pixFloor);
    }


}
