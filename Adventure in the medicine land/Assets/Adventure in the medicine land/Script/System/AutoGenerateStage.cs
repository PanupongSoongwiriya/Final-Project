using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class AutoGenerateStage : MonoBehaviour
{
    public Texture2D image;
    Dictionary<string, Color> typeColor = new Dictionary<string, Color>();
    public float tolerancea = 0.04f;

    private GameSystem gameSystem;

    public int phase = 90;//width of one channel
    public int scaleFloor = 6;
    private int start_x;//half of phase
    private int start_y;//half of phase
    public int bonusFloor = 1;

    public GameObject floorModel;
    public GameObject lineModel;
    public GameObject characterModel;
    private GameObject floorObject;
    private GameObject characterObject;

    void Start()
    {
        start_x = phase / 2;
        start_y = phase / 2;
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        setColor();
        readStageImage();
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
        typeColor.Add("chartreuse", new Color(0.4980392f, 1, 0, 1f));//ยาแก้ปวดท้อง
        typeColor.Add("pink", new Color(1f, 0.7529412f, 0.7960784f, 1f));//ยาแก้ปวดหัว
        typeColor.Add("yellow", new Color(1f, 1f, 0f, 1f));//ยาลดน้ำมูก
        typeColor.Add("hotpink", new Color(1, 0.4117647f, 0.7058824f, 1f));//ยาฆ่าเชื้อ
        typeColor.Add("turquoise", new Color(0.2509804f, 0.8784314f, 0.8156863f, 1f));//ยาแก้คัน
        typeColor.Add("violet", new Color(0.9333333f, 0.509804f, 0.9333333f, 1f));//ยาฆ่าเชื้อสิว
        typeColor.Add("coral", new Color(1f, 0.4980392f, 0.3137255f, 1f));//ยาแก้ปวดกล้ามเนื้อ
        typeColor.Add("indianred", new Color(0.8039216f, 0.3607843f, 0.3607843f, 1f));//ยาฆ่าเชื้อรา
        typeColor.Add("darkblue", new Color(0f, 0f, 0.5450981f, 1f));//ยาบำรุงสมอง
        typeColor.Add("crimson", new Color(0.8627451f, 0.07843138f, 0.2352941f, 1f));//ยาบำรุงเลือด
        typeColor.Add("chocolate", new Color(0.8235294f, 0.4117647f, 0.1176471f, 1f));//ยาบำรุงกระดูก
        typeColor.Add("gold", new Color(1f, 0.8431373f, 0f, 1f));//ฮีโร่
        typeColor.Add("olivedrab", new Color(0.4196078f, 0.5568628f, 0.1372549f, 1f));//ปวดท้อง
        typeColor.Add("darkcyan", new Color(0f, 0.5450981f, 0.5450981f, 1f));//ปวดหัว
        typeColor.Add("green", new Color(0f, 0.5019608f, 0f, 1f));//น้ำมูกไหล
        typeColor.Add("lightsteelblue", new Color(0.6901961f, 0.7686275f, 0.8705882f, 1f));//ติดเชื้อ
        typeColor.Add("peru", new Color(0.8039216f, 0.5215687f, 0.2470588f, 1f));//อาการคัน
        typeColor.Add("navajowhite", new Color(1f, 0.8705882f, 0.6784314f, 1f));//สิว
        typeColor.Add("palevioletred", new Color(0.8588235f, 0.4392157f, 0.5764706f, 1f));//ปวดกล้ามเนื้อ
        typeColor.Add("lightyellow", new Color(1f, 1f, 0.8784314f, 1f));//เชื้อราที่ผิวหนัง
        typeColor.Add("mediumslateblue", new Color(0.4823529f, 0.4078431f, 0.9333333f, 1f));//จอมมาร
    }
    private void readStageImage()
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
                Color pix = image.GetPixel((start_x + x), (start_y + y));
                Color pixFloor = image.GetPixel((start_x + x), (int)((start_y * 0.2f) + y));
                if ((!((((typeColor["black"].r - tolerancea) < pixFloor.r) && (pixFloor.r < (typeColor["black"].r + tolerancea))) 
                    && (((typeColor["black"].g - tolerancea) < pixFloor.g) && (pixFloor.g < (typeColor["black"].g + tolerancea))) 
                    && (((typeColor["black"].b - tolerancea) < pixFloor.b) && (pixFloor.b < (typeColor["black"].b + tolerancea))))))
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
                if ((!((((typeColor["black"].r - tolerancea) < pix.r) && (pix.r < (typeColor["black"].r + tolerancea)))
                    && (((typeColor["black"].g - tolerancea) < pix.g) && (pix.g < (typeColor["black"].g + tolerancea)))
                    && (((typeColor["black"].b - tolerancea) < pix.b) && (pix.b < (typeColor["black"].b + tolerancea)))))
                    && (!((((typeColor["white"].r - tolerancea) < pix.r) && (pix.r < (typeColor["white"].r + tolerancea)))
                    && (((typeColor["white"].g - tolerancea) < pix.g) && (pix.g < (typeColor["white"].g + tolerancea)))
                    && (((typeColor["white"].b - tolerancea) < pix.b) && (pix.b < (typeColor["white"].b + tolerancea)))))
                    && ((!((((pix.r - tolerancea) < pixFloor.r) && (pixFloor.r < (pix.r + tolerancea)))
                    && (((pix.g - tolerancea) < pixFloor.g) && (pixFloor.g < (pix.g + tolerancea)))
                    && (((pix.b - tolerancea) < pixFloor.b) && (pixFloor.b < (pix.b + tolerancea)))))))
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
                    generateCharacter(floor_x, floor_z, pix);
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
        if ((((typeColor["white"].r - tolerancea) < pixFloor.r) && (pixFloor.r < (typeColor["white"].r + tolerancea))) && (((typeColor["white"].g - tolerancea) < pixFloor.g) && (pixFloor.g < (typeColor["white"].g + tolerancea))) && (((typeColor["white"].b - tolerancea) < pixFloor.b) && (pixFloor.b < (typeColor["white"].b + tolerancea))))
        {
            //Norma
            floorObject.AddComponent<Floor>();
        }

        else if (((((typeColor["red"].r - tolerancea) < pixFloor.r) && (pixFloor.r < (typeColor["red"].r + tolerancea))) && (((typeColor["red"].g - tolerancea) < pixFloor.g) && (pixFloor.g < (typeColor["red"].g + tolerancea))) && (((typeColor["red"].b - tolerancea) < pixFloor.b) && (pixFloor.b < (typeColor["red"].b + tolerancea)))))
        {
            //+ATK
            floorObject.AddComponent<floorATK>().SA = bonusFloor;
        }

        else if (((((typeColor["cyan"].r - tolerancea) < pixFloor.r) && (pixFloor.r < (typeColor["cyan"].r + tolerancea))) && (((typeColor["cyan"].g - tolerancea) < pixFloor.g) && (pixFloor.g < (typeColor["cyan"].g + tolerancea))) && (((typeColor["cyan"].b - tolerancea) < pixFloor.b) && (pixFloor.b < (typeColor["cyan"].b + tolerancea)))))
        {
            //-ATK
            floorObject.AddComponent<floorATK>().SA = -bonusFloor;
        }

        else if (((((typeColor["gray"].r - tolerancea) < pixFloor.r) && (pixFloor.r < (typeColor["gray"].r + tolerancea))) && (((typeColor["gray"].g - tolerancea) < pixFloor.g) && (pixFloor.g < (typeColor["gray"].g + tolerancea))) && (((typeColor["gray"].b - tolerancea) < pixFloor.b) && (pixFloor.b < (typeColor["gray"].b + tolerancea)))))
        {
            //+DEF
            floorObject.AddComponent<floorDEF>().SD = bonusFloor;
        }

        else if (((((typeColor["brown"].r - tolerancea) < pixFloor.r) && (pixFloor.r < (typeColor["brown"].r + tolerancea))) && (((typeColor["brown"].g - tolerancea) < pixFloor.g) && (pixFloor.g < (typeColor["brown"].g + tolerancea))) && (((typeColor["brown"].b - tolerancea) < pixFloor.b) && (pixFloor.b < (typeColor["brown"].b + tolerancea)))))
        {
            //-DEF
            floorObject.AddComponent<floorDEF>().SD = -bonusFloor;
        }

        else if (((((typeColor["purple"].r - tolerancea) < pixFloor.r) && (pixFloor.r < (typeColor["purple"].r + tolerancea))) && (((typeColor["purple"].g - tolerancea) < pixFloor.g) && (pixFloor.g < (typeColor["purple"].g + tolerancea))) && (((typeColor["purple"].b - tolerancea) < pixFloor.b) && (pixFloor.b < (typeColor["purple"].b + tolerancea)))))
        {
            //Poison
            floorObject.AddComponent<floorPoison>();
        }
    }
    private void generateCharacter(int x_Coordinate, int z_Coordinate, Color pix)
    {
        characterObject = Instantiate(characterModel, new Vector3(x_Coordinate, 2, z_Coordinate), transform.rotation);
        characterObject.GetComponent<Renderer>().material.SetColor("_Color", pix);
        if (((((typeColor["chartreuse"].r - tolerancea) < pix.r) && (pix.r < (typeColor["chartreuse"].r + tolerancea))) && (((typeColor["chartreuse"].g - tolerancea) < pix.g) && (pix.g < (typeColor["chartreuse"].g + tolerancea))) && (((typeColor["chartreuse"].b - tolerancea) < pix.b) && (pix.b < (typeColor["chartreuse"].b + tolerancea)))))
        {
            //ยาแก้ปวดท้อง
            characterObject.AddComponent<StomachPainReliever>();
        }

        else if (((((typeColor["pink"].r - tolerancea) < pix.r) && (pix.r < (typeColor["pink"].r + tolerancea))) && (((typeColor["pink"].g - tolerancea) < pix.g) && (pix.g < (typeColor["pink"].g + tolerancea))) && (((typeColor["pink"].b - tolerancea) < pix.b) && (pix.b < (typeColor["pink"].b + tolerancea)))))
        {
            //ยาแก้ปวดหัว
            characterObject.AddComponent<HeadacheMedicine>();
        }

        else if (((((typeColor["yellow"].r - tolerancea) < pix.r) && (pix.r < (typeColor["yellow"].r + tolerancea))) && (((typeColor["yellow"].g - tolerancea) < pix.g) && (pix.g < (typeColor["yellow"].g + tolerancea))) && (((typeColor["yellow"].b - tolerancea) < pix.b) && (pix.b < (typeColor["yellow"].b + tolerancea)))))
        {
            //ยาลดน้ำมูก
            characterObject.AddComponent<Decongestant>();
        }

        else if (((((typeColor["hotpink"].r - tolerancea) < pix.r) && (pix.r < (typeColor["hotpink"].r + tolerancea))) && (((typeColor["hotpink"].g - tolerancea) < pix.g) && (pix.g < (typeColor["hotpink"].g + tolerancea))) && (((typeColor["hotpink"].b - tolerancea) < pix.b) && (pix.b < (typeColor["hotpink"].b + tolerancea)))))
        {
            //ยาฆ่าเชื้อ
            characterObject.AddComponent<Antibiotic>();
        }

        else if (((((typeColor["turquoise"].r - tolerancea) < pix.r) && (pix.r < (typeColor["turquoise"].r + tolerancea))) && (((typeColor["turquoise"].g - tolerancea) < pix.g) && (pix.g < (typeColor["turquoise"].g + tolerancea))) && (((typeColor["turquoise"].b - tolerancea) < pix.b) && (pix.b < (typeColor["turquoise"].b + tolerancea)))))
        {
            //ยาแก้คัน
            characterObject.AddComponent<Antipruritic>();
        }

        else if (((((typeColor["violet"].r - tolerancea) < pix.r) && (pix.r < (typeColor["violet"].r + tolerancea))) && (((typeColor["violet"].g - tolerancea) < pix.g) && (pix.g < (typeColor["violet"].g + tolerancea))) && (((typeColor["violet"].b - tolerancea) < pix.b) && (pix.b < (typeColor["violet"].b + tolerancea)))))
        {
            //ยาฆ่าเชื้อสิว
            characterObject.AddComponent<AcneDisinfectant>();
        }

        else if (((((typeColor["coral"].r - tolerancea) < pix.r) && (pix.r < (typeColor["coral"].r + tolerancea))) && (((typeColor["coral"].g - tolerancea) < pix.g) && (pix.g < (typeColor["coral"].g + tolerancea))) && (((typeColor["coral"].b - tolerancea) < pix.b) && (pix.b < (typeColor["coral"].b + tolerancea)))))
        {
            //ยาแก้ปวดกล้ามเนื้อ
            characterObject.AddComponent<MusclePainMedication>();
        }

        else if (((((typeColor["indianred"].r - tolerancea) < pix.r) && (pix.r < (typeColor["indianred"].r + tolerancea))) && (((typeColor["indianred"].g - tolerancea) < pix.g) && (pix.g < (typeColor["indianred"].g + tolerancea))) && (((typeColor["indianred"].b - tolerancea) < pix.b) && (pix.b < (typeColor["indianred"].b + tolerancea)))))
        {
            //ยาฆ่าเชื้อรา
            characterObject.AddComponent<Fungicide>();
        }

        else if (((((typeColor["darkblue"].r - tolerancea) < pix.r) && (pix.r < (typeColor["darkblue"].r + tolerancea))) && (((typeColor["darkblue"].g - tolerancea) < pix.g) && (pix.g < (typeColor["darkblue"].g + tolerancea))) && (((typeColor["darkblue"].b - tolerancea) < pix.b) && (pix.b < (typeColor["darkblue"].b + tolerancea)))))
        {
            //ยาบำรุงสมอง
            characterObject.AddComponent<BrainTonic>();
        }

        else if (((((typeColor["crimson"].r - tolerancea) < pix.r) && (pix.r < (typeColor["crimson"].r + tolerancea))) && (((typeColor["crimson"].g - tolerancea) < pix.g) && (pix.g < (typeColor["crimson"].g + tolerancea))) && (((typeColor["crimson"].b - tolerancea) < pix.b) && (pix.b < (typeColor["crimson"].b + tolerancea)))))
        {
            //ยาบำรุงเลือด
            characterObject.AddComponent<BloodTonic>();
        }

        else if (((((typeColor["chocolate"].r - tolerancea) < pix.r) && (pix.r < (typeColor["chocolate"].r + tolerancea))) && (((typeColor["chocolate"].g - tolerancea) < pix.g) && (pix.g < (typeColor["chocolate"].g + tolerancea))) && (((typeColor["chocolate"].b - tolerancea) < pix.b) && (pix.b < (typeColor["chocolate"].b + tolerancea)))))
        {
            //ยาบำรุงกระดูก
            characterObject.AddComponent<BoneTonic>();
        }

        else if (((((typeColor["gold"].r - tolerancea) < pix.r) && (pix.r < (typeColor["gold"].r + tolerancea))) && (((typeColor["gold"].g - tolerancea) < pix.g) && (pix.g < (typeColor["gold"].g + tolerancea))) && (((typeColor["gold"].b - tolerancea) < pix.b) && (pix.b < (typeColor["gold"].b + tolerancea)))))
        {
            //ฮีโร่
            characterObject.AddComponent<Hero>();
        }

        else if (((((typeColor["olivedrab"].r - tolerancea) < pix.r) && (pix.r < (typeColor["olivedrab"].r + tolerancea))) && (((typeColor["olivedrab"].g - tolerancea) < pix.g) && (pix.g < (typeColor["olivedrab"].g + tolerancea))) && (((typeColor["olivedrab"].b - tolerancea) < pix.b) && (pix.b < (typeColor["olivedrab"].b + tolerancea)))))
        {
            //ปวดท้อง
            characterObject.AddComponent<Stomachache>();
        }

        else if (((((typeColor["darkcyan"].r - tolerancea) < pix.r) && (pix.r < (typeColor["darkcyan"].r + tolerancea))) && (((typeColor["darkcyan"].g - tolerancea) < pix.g) && (pix.g < (typeColor["darkcyan"].g + tolerancea))) && (((typeColor["darkcyan"].b - tolerancea) < pix.b) && (pix.b < (typeColor["darkcyan"].b + tolerancea)))))
        {
            //ปวดหัว
            characterObject.AddComponent<Headache>();
        }

        else if (((((typeColor["green"].r - tolerancea) < pix.r) && (pix.r < (typeColor["green"].r + tolerancea))) && (((typeColor["green"].g - tolerancea) < pix.g) && (pix.g < (typeColor["green"].g + tolerancea))) && (((typeColor["green"].b - tolerancea) < pix.b) && (pix.b < (typeColor["green"].b + tolerancea)))))
        {
            //น้ำมูกไหล
            characterObject.AddComponent<RunnyNose>();
        }

        else if (((((typeColor["lightsteelblue"].r - tolerancea) < pix.r) && (pix.r < (typeColor["lightsteelblue"].r + tolerancea))) && (((typeColor["lightsteelblue"].g - tolerancea) < pix.g) && (pix.g < (typeColor["lightsteelblue"].g + tolerancea))) && (((typeColor["lightsteelblue"].b - tolerancea) < pix.b) && (pix.b < (typeColor["lightsteelblue"].b + tolerancea)))))
        {
            //ติดเชื้อ
            characterObject.AddComponent<Infect>();
        }

        else if (((((typeColor["peru"].r - tolerancea) < pix.r) && (pix.r < (typeColor["peru"].r + tolerancea))) && (((typeColor["peru"].g - tolerancea) < pix.g) && (pix.g < (typeColor["peru"].g + tolerancea))) && (((typeColor["peru"].b - tolerancea) < pix.b) && (pix.b < (typeColor["peru"].b + tolerancea)))))
        {
            //อาการคัน
            characterObject.AddComponent<Itching>();
        }

        else if (((((typeColor["navajowhite"].r - tolerancea) < pix.r) && (pix.r < (typeColor["navajowhite"].r + tolerancea))) && (((typeColor["navajowhite"].g - tolerancea) < pix.g) && (pix.g < (typeColor["navajowhite"].g + tolerancea))) && (((typeColor["navajowhite"].b - tolerancea) < pix.b) && (pix.b < (typeColor["navajowhite"].b + tolerancea)))))
        {
            //สิว
            characterObject.AddComponent<Acne>();
        }

        else if (((((typeColor["palevioletred"].r - tolerancea) < pix.r) && (pix.r < (typeColor["palevioletred"].r + tolerancea))) && (((typeColor["palevioletred"].g - tolerancea) < pix.g) && (pix.g < (typeColor["palevioletred"].g + tolerancea))) && (((typeColor["palevioletred"].b - tolerancea) < pix.b) && (pix.b < (typeColor["palevioletred"].b + tolerancea)))))
        {
            //ปวดกล้ามเนื้อ
            characterObject.AddComponent<MusclePain>();
        }

        else if (((((typeColor["lightyellow"].r - tolerancea) < pix.r) && (pix.r < (typeColor["lightyellow"].r + tolerancea))) && (((typeColor["lightyellow"].g - tolerancea) < pix.g) && (pix.g < (typeColor["lightyellow"].g + tolerancea))) && (((typeColor["lightyellow"].b - tolerancea) < pix.b) && (pix.b < (typeColor["lightyellow"].b + tolerancea)))))
        {
            //เชื้อราที่ผิวหนัง
            characterObject.AddComponent<SkinFungus>();
        }

        else if (((((typeColor["mediumslateblue"].r - tolerancea) < pix.r) && (pix.r < (typeColor["mediumslateblue"].r + tolerancea))) && (((typeColor["mediumslateblue"].g - tolerancea) < pix.g) && (pix.g < (typeColor["mediumslateblue"].g + tolerancea))) && (((typeColor["mediumslateblue"].b - tolerancea) < pix.b) && (pix.b < (typeColor["mediumslateblue"].b + tolerancea)))))
        {
            //จอมมาร
            characterObject.AddComponent<DemonLord>();
        }
    }
}
