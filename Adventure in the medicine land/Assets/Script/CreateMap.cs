using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class CreateMap : MonoBehaviour
{
    public GameObject floorModel;

    private GameObject floorObject;

    public Texture2D image;
    Dictionary<string, Color> typeColor = new Dictionary<string, Color>();

    public GameObject system;
    private GameSystem gameSystem;

    void Start()
    {
        gameSystem = system.GetComponent<GameSystem>();
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
        int start_x = 45;
        int start_y = 45;
        for (int x = 0; x < image.width; x += 90)
        {
            for (int y = 0; y < image.height; y += 90)
            {
                Color pixFloor = image.GetPixel((start_x + x), (start_y + y));
                if (!pixFloor.gamma.Equals(typeColor["black"].gamma))
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
        gameSystem.allFloor.Add(floorObject);
        if (pixFloor.gamma.Equals(typeColor["white"].gamma))//Normal
        {
            floorObject.AddComponent<Floor>().system = system;
            floorObject.GetComponents<Floor>()[0].setTypeFloor("white", pixFloor);//test
        }
        else if (pixFloor.gamma.Equals(typeColor["red"].gamma))//+ATK
        {
            floorObject.AddComponent<Floor>().system = system;
            floorObject.GetComponents<Floor>()[0].setTypeFloor("red", pixFloor);//test
        }
        else if (pixFloor.gamma.Equals(typeColor["cyan"].gamma))//-ATK
        {
            floorObject.AddComponent<Floor>().system = system;
            floorObject.GetComponents<Floor>()[0].setTypeFloor("cyan", pixFloor);//test
        }
        else if (pixFloor.gamma.Equals(typeColor["gray"].gamma))//+DEF
        {
            floorObject.AddComponent<Floor>().system = system;
            floorObject.GetComponents<Floor>()[0].setTypeFloor("gray", pixFloor);//test
        }
        else if (pixFloor.gamma.Equals(typeColor["brown"].gamma))//-DEF
        {
            floorObject.AddComponent<Floor>().system = system;
            floorObject.GetComponents<Floor>()[0].setTypeFloor("brown", pixFloor);//test
        }
        else if (pixFloor.gamma.Equals(typeColor["purple"].gamma))//Poison
        {
            floorObject.AddComponent<Floor>().system = system;
            floorObject.GetComponents<Floor>()[0].setTypeFloor("purple", pixFloor);//test
        }
    }


}
