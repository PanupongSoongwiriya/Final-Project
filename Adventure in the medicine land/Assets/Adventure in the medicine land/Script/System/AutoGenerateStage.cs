using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class AutoGenerateStage : MonoBehaviour
{
    public List<Texture2D> allStage = new List<Texture2D>();
    public Texture2D image;
    Dictionary<string, Color> typeColor = new Dictionary<string, Color>();
    private float tolerancea = 0.04f;
    public SaveManager sm;

    [SerializeField]
    private GameSystem gameSystem;

    private int phase;//width of one channel
    public int numWidth;//num of all channel in image width
    private int scaleFloor;
    private int start_x;//half of phase
    private int start_y;//half of phase
    public int floorBonus = 1;

    public GameObject floorModel;
    public GameObject lineModel;
    public GameObject characterModel;
    private GameObject floorObject;
    private GameObject characterObject;
    private GameObject lineObject;

    private GameObject Map;

    [SerializeField]
    private GameObject CharacterStoragePrefab;
    [SerializeField]
    private GameObject FloorStoragePrefab;

    [SerializeField]
    private Component[] CharacterPrefab;
    [SerializeField]
    private Component[] FloorPrefab;
    [SerializeField]
    private float prefabSize;

    public int ChrCount;

    [SerializeField]
    private List<Texture> Bg_Image = new List<Texture>();
    [SerializeField]
    private Renderer Bg_Oject;


    void Start()
    {
        sm.Load();
        Debug.Log("SaveManager: " + sm.state.storyOrder);
        CharacterPrefab = CharacterStoragePrefab.GetComponents(typeof(CharacterPrefab));
        FloorPrefab = FloorStoragePrefab.GetComponents(typeof(FloorPrefab));
        Bg_Oject.material.mainTexture = Bg_Image[sm.state.storyOrder+1];
        if (image == null)
        {
            //image = allStage[new System.Random().Next(allStage.Count)];
            image = allStage[sm.state.storyOrder];
        }
        numWidth = int.Parse(image.name.Split(char.Parse("x"))[1]);
        phase = image.width / numWidth;
        scaleFloor = (int)floorModel.transform.localScale.x;
        start_x = phase / 2;
        start_y = phase / 2;
        try
        {
            gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        }
        catch (Exception e)
        {
            gameSystem = GameObject.Find("TutorialSystem").GetComponent<GameSystem>();
        }
        Map = new GameObject("Map");
        setColor();
        readStageImage();
        gameSystem.AGS = this;
        gameSystem.saveManager = sm.state.storyOrder;
        GameObject.Find("Game Camera").GetComponent<PerspectivePan>().NumWidth = numWidth;

        
    }

    void Update()
    {
        if (gameSystem.diseaseFaction.Count + gameSystem.medicineFaction.Count == ChrCount)
        {
            foreach (Character disease in gameSystem.diseaseFaction)
            {
                disease.setDegree();
            }
            foreach (Character medicine in gameSystem.medicineFaction)
            {
                medicine.setDegree();
            }
            ++ChrCount;
        }
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
        typeColor.Add("snow", new Color(0.8509804f, 0.8196079f, 0.8078431f, 1f));//ภูเขา
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
    public void readStageImage()
    {
        ChrCount = 0;
        bool horizontalLine = true;
        int count_id = 1;
        int lineX = (((((10 - numWidth) * 10) / 2) * 6) / 10) - 3;

        if (!gameSystem.endGame)
        {
            //Generate Vertical Line
            lineObject = Instantiate(lineModel, new Vector3(lineX, 0, 3), transform.rotation);
            lineObject.transform.localScale = new Vector3(((image.width / phase) * scaleFloor), 0.1f, 0.1f);
            lineObject.transform.parent = Map.transform;

            //Generate Horizontal Line
            lineObject = Instantiate(lineModel, new Vector3(((image.width / phase) * 3) + lineX, 0, ((image.height / phase) * 3) + 3), transform.rotation);
            lineObject.transform.localScale = new Vector3(0.1f, 0.1f, ((image.height / phase) * scaleFloor));
            lineObject.transform.parent = Map.transform;

        }
        for (int x = 0; x < image.width; x += phase)
        {
            if (!gameSystem.endGame)
            {
                //Generate Vertical Line
                lineObject = Instantiate(lineModel, new Vector3(lineX, 0, (((x + phase) / phase) * scaleFloor) + 3), transform.rotation);
                lineObject.transform.localScale = new Vector3(((image.width / phase) * scaleFloor), 0.1f, 0.1f);
                lineObject.transform.parent = Map.transform;
                //Generate Vertical Line
            }
            for (int y = 0; y < image.height; y += phase)
            {
                Color pix = image.GetPixel((start_x + x), (start_y + y));
                //Debug.Log("pix: " + pix.r + ", " + pix.g + ", " + pix.b);
                Color pixFloor = image.GetPixel((start_x + x), (int)((start_y * 0.2f) + y));
                if ((!((((typeColor["black"].r - tolerancea) < pixFloor.r) && (pixFloor.r < (typeColor["black"].r + tolerancea)))
                   && (((typeColor["black"].g - tolerancea) < pixFloor.g) && (pixFloor.g < (typeColor["black"].g + tolerancea)))
                   && (((typeColor["black"].b - tolerancea) < pixFloor.b) && (pixFloor.b < (typeColor["black"].b + tolerancea)))))
                   && !gameSystem.endGame)
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
                if (horizontalLine && !gameSystem.endGame)
                {
                    lineObject = Instantiate(lineModel, new Vector3(((image.width / phase) * (scaleFloor / 2)) + lineX - (scaleFloor * ((y + phase) / phase)), 0, ((image.height / phase) * (scaleFloor / 2)) + 3), transform.rotation);
                    lineObject.transform.localScale = new Vector3(0.1f, 0.1f, ((image.height / phase) * scaleFloor));
                    lineObject.transform.parent = Map.transform;
                }
            }
            horizontalLine = false;
        }
    }
    private void setFloorModel(string whatKindFloor, int x_Coordinate, int z_Coordinate)
    {
        foreach (FloorPrefab fp in FloorPrefab)
        {
            if (fp.whatKindFloor.Equals(whatKindFloor))
            {
                floorObject = Instantiate(fp.prefab, new Vector3(x_Coordinate, 0, z_Coordinate), transform.rotation);
                break;
            }
        }
    }
    private void generateFloor(int x_Coordinate, int z_Coordinate, Color pixFloor, int id)
    {
        bool add = true;
        if ((((typeColor["white"].r - tolerancea) < pixFloor.r) && (pixFloor.r < (typeColor["white"].r + tolerancea))) && (((typeColor["white"].g - tolerancea) < pixFloor.g) && (pixFloor.g < (typeColor["white"].g + tolerancea))) && (((typeColor["white"].b - tolerancea) < pixFloor.b) && (pixFloor.b < (typeColor["white"].b + tolerancea))))
        {
            //Normal
            setFloorModel("Normal", x_Coordinate, z_Coordinate);
            floorObject.AddComponent<Floor>();
        }

        else if (((((typeColor["red"].r - tolerancea) < pixFloor.r) && (pixFloor.r < (typeColor["red"].r + tolerancea))) && (((typeColor["red"].g - tolerancea) < pixFloor.g) && (pixFloor.g < (typeColor["red"].g + tolerancea))) && (((typeColor["red"].b - tolerancea) < pixFloor.b) && (pixFloor.b < (typeColor["red"].b + tolerancea)))))
        {
            //+ATK
            setFloorModel("+ATK", x_Coordinate, z_Coordinate);
            floorObject.AddComponent<floorATK>().FloorBonus = floorBonus;
        }

        else if (((((typeColor["cyan"].r - tolerancea) < pixFloor.r) && (pixFloor.r < (typeColor["cyan"].r + tolerancea))) && (((typeColor["cyan"].g - tolerancea) < pixFloor.g) && (pixFloor.g < (typeColor["cyan"].g + tolerancea))) && (((typeColor["cyan"].b - tolerancea) < pixFloor.b) && (pixFloor.b < (typeColor["cyan"].b + tolerancea)))))
        {
            //-ATK
            setFloorModel("-ATK", x_Coordinate, z_Coordinate);
            floorObject.AddComponent<floorATK>().FloorBonus = -floorBonus;
            floorObject.transform.rotation = Quaternion.Euler(floorObject.transform.rotation.x, 90 * UnityEngine.Random.Range(0, 3), floorObject.transform.rotation.z);
        }

        else if (((((typeColor["gray"].r - tolerancea) < pixFloor.r) && (pixFloor.r < (typeColor["gray"].r + tolerancea))) && (((typeColor["gray"].g - tolerancea) < pixFloor.g) && (pixFloor.g < (typeColor["gray"].g + tolerancea))) && (((typeColor["gray"].b - tolerancea) < pixFloor.b) && (pixFloor.b < (typeColor["gray"].b + tolerancea)))))
        {
            //+DEF
            setFloorModel("+DEF", x_Coordinate, z_Coordinate);
            floorObject.AddComponent<floorDEF>().FloorBonus = floorBonus;
        }

        else if (((((typeColor["brown"].r - tolerancea) < pixFloor.r) && (pixFloor.r < (typeColor["brown"].r + tolerancea))) && (((typeColor["brown"].g - tolerancea) < pixFloor.g) && (pixFloor.g < (typeColor["brown"].g + tolerancea))) && (((typeColor["brown"].b - tolerancea) < pixFloor.b) && (pixFloor.b < (typeColor["brown"].b + tolerancea)))))
        {
            //-DEF
            setFloorModel("-DEF", x_Coordinate, z_Coordinate);
            floorObject.AddComponent<floorDEF>().FloorBonus = -floorBonus;
            floorObject.transform.rotation = Quaternion.Euler(floorObject.transform.rotation.x, 90 * UnityEngine.Random.Range(0, 3), floorObject.transform.rotation.z);
        }

        else if (((((typeColor["purple"].r - tolerancea) < pixFloor.r) && (pixFloor.r < (typeColor["purple"].r + tolerancea))) && (((typeColor["purple"].g - tolerancea) < pixFloor.g) && (pixFloor.g < (typeColor["purple"].g + tolerancea))) && (((typeColor["purple"].b - tolerancea) < pixFloor.b) && (pixFloor.b < (typeColor["purple"].b + tolerancea)))))
        {
            //Poison
            setFloorModel("Poison", x_Coordinate, z_Coordinate);
            floorObject.AddComponent<floorPoison>().FloorBonus = floorBonus;
            floorObject.transform.rotation = Quaternion.Euler(floorObject.transform.rotation.x, 90 * UnityEngine.Random.Range(0, 3), floorObject.transform.rotation.z);
        }
        else if (((((typeColor["snow"].r - tolerancea) < pixFloor.r) && (pixFloor.r < (typeColor["snow"].r + tolerancea))) && (((typeColor["snow"].g - tolerancea) < pixFloor.g) && (pixFloor.g < (typeColor["snow"].g + tolerancea))) && (((typeColor["snow"].b - tolerancea) < pixFloor.b) && (pixFloor.b < (typeColor["snow"].b + tolerancea)))))
        {
            //Mountain
            add = false;
            setFloorModel("Mountain", x_Coordinate, z_Coordinate);
            floorObject.transform.rotation = Quaternion.Euler(floorObject.transform.rotation.x, 90 * UnityEngine.Random.Range(0, 3), floorObject.transform.rotation.z);
            
        }
        floorObject.name = "floor " + id;
        if (add)
        {
            gameSystem.allFloor.Add(floorObject);
        }
        floorObject.transform.parent = Map.transform;
    }

    private void setCharacterModel(string classCharacter, int x_Coordinate, int z_Coordinate, Color pix)
    {
        bool find = false;
        foreach (CharacterPrefab cp in CharacterPrefab)
        {
            if (cp.classCharacter.Equals(classCharacter))
            {
                find = true;
                characterObject = Instantiate(cp.prefab, new Vector3(x_Coordinate, 0, z_Coordinate), transform.rotation);
                break;
            }
        }
        if (!find)
        {
            characterObject = Instantiate(characterModel, new Vector3(x_Coordinate, 2, z_Coordinate), transform.rotation);
            characterObject.GetComponent<Renderer>().material.SetColor("_Color", pix);
        }
    }
    private void setCharacterSprite(string classCharacter)
    {
        foreach (CharacterPrefab cp in CharacterPrefab)
        {
            if (cp.classCharacter.Equals(classCharacter))
            {
                characterObject.GetComponent<Character>().image = cp.image;
                break;
            }
        }
    }

    private void generateCharacter(int x_Coordinate, int z_Coordinate, Color pix)
    {
        ++ChrCount;
        if (((((typeColor["chartreuse"].r - tolerancea) < pix.r) && (pix.r < (typeColor["chartreuse"].r + tolerancea))) && (((typeColor["chartreuse"].g - tolerancea) < pix.g) && (pix.g < (typeColor["chartreuse"].g + tolerancea))) && (((typeColor["chartreuse"].b - tolerancea) < pix.b) && (pix.b < (typeColor["chartreuse"].b + tolerancea)))))
        {
            //พลธนู 1
            setCharacterModel("Archer", x_Coordinate, z_Coordinate, pix);
            characterObject.AddComponent<Archer>();
            setCharacterSprite("Archer");
        }

        else if (((((typeColor["pink"].r - tolerancea) < pix.r) && (pix.r < (typeColor["pink"].r + tolerancea))) && (((typeColor["pink"].g - tolerancea) < pix.g) && (pix.g < (typeColor["pink"].g + tolerancea))) && (((typeColor["pink"].b - tolerancea) < pix.b) && (pix.b < (typeColor["pink"].b + tolerancea)))))
        {
            //พลธนู 2
            setCharacterModel("Sniper", x_Coordinate, z_Coordinate, pix);
            characterObject.AddComponent<Sniper>();
            setCharacterSprite("Sniper");
        }

        else if (((((typeColor["yellow"].r - tolerancea) < pix.r) && (pix.r < (typeColor["yellow"].r + tolerancea))) && (((typeColor["yellow"].g - tolerancea) < pix.g) && (pix.g < (typeColor["yellow"].g + tolerancea))) && (((typeColor["yellow"].b - tolerancea) < pix.b) && (pix.b < (typeColor["yellow"].b + tolerancea)))))
        {
            //พลขวาน
            setCharacterModel("Ax", x_Coordinate, z_Coordinate, pix);
            characterObject.AddComponent<Ax>();
            setCharacterSprite("Ax");
        }

        else if (((((typeColor["turquoise"].r - tolerancea) < pix.r) && (pix.r < (typeColor["turquoise"].r + tolerancea))) && (((typeColor["turquoise"].g - tolerancea) < pix.g) && (pix.g < (typeColor["turquoise"].g + tolerancea))) && (((typeColor["turquoise"].b - tolerancea) < pix.b) && (pix.b < (typeColor["turquoise"].b + tolerancea)))))
        {
            //พลดาบโล่
            setCharacterModel("Shield_Swords_Man", x_Coordinate, z_Coordinate, pix);
            characterObject.AddComponent<Shield_Swords_Man>();
            setCharacterSprite("Shield_Swords_Man");
        }

        else if (((((typeColor["violet"].r - tolerancea) < pix.r) && (pix.r < (typeColor["violet"].r + tolerancea))) && (((typeColor["violet"].g - tolerancea) < pix.g) && (pix.g < (typeColor["violet"].g + tolerancea))) && (((typeColor["violet"].b - tolerancea) < pix.b) && (pix.b < (typeColor["violet"].b + tolerancea)))))
        {
            //พลขวานโล่
            setCharacterModel("Shield_Ax_Man", x_Coordinate, z_Coordinate, pix);
            characterObject.AddComponent<Shield_Ax_Man>();
            setCharacterSprite("Shield_Ax_Man");
        }

        else if (((((typeColor["coral"].r - tolerancea) < pix.r) && (pix.r < (typeColor["coral"].r + tolerancea))) && (((typeColor["coral"].g - tolerancea) < pix.g) && (pix.g < (typeColor["coral"].g + tolerancea))) && (((typeColor["coral"].b - tolerancea) < pix.b) && (pix.b < (typeColor["coral"].b + tolerancea)))))
        {
            //พลค้อน
            setCharacterModel("Hammer", x_Coordinate, z_Coordinate, pix);
            characterObject.AddComponent<Hammer>();
            setCharacterSprite("Hammer");
        }

        else if (((((typeColor["indianred"].r - tolerancea) < pix.r) && (pix.r < (typeColor["indianred"].r + tolerancea))) && (((typeColor["indianred"].g - tolerancea) < pix.g) && (pix.g < (typeColor["indianred"].g + tolerancea))) && (((typeColor["indianred"].b - tolerancea) < pix.b) && (pix.b < (typeColor["indianred"].b + tolerancea)))))
        {
            //นายพล
            setCharacterModel("General", x_Coordinate, z_Coordinate, pix);
            characterObject.AddComponent<General>();
            setCharacterSprite("General");
        }

        else if (((((typeColor["darkblue"].r - tolerancea) < pix.r) && (pix.r < (typeColor["darkblue"].r + tolerancea))) && (((typeColor["darkblue"].g - tolerancea) < pix.g) && (pix.g < (typeColor["darkblue"].g + tolerancea))) && (((typeColor["darkblue"].b - tolerancea) < pix.b) && (pix.b < (typeColor["darkblue"].b + tolerancea)))))
        {
            //หน่วยสนับสนุน
            setCharacterModel("Nurse", x_Coordinate, z_Coordinate, pix);
            characterObject.AddComponent<Nurse>();
            setCharacterSprite("Nurse");
        }

        else if (((((typeColor["crimson"].r - tolerancea) < pix.r) && (pix.r < (typeColor["crimson"].r + tolerancea))) && (((typeColor["crimson"].g - tolerancea) < pix.g) && (pix.g < (typeColor["crimson"].g + tolerancea))) && (((typeColor["crimson"].b - tolerancea) < pix.b) && (pix.b < (typeColor["crimson"].b + tolerancea)))))
        {
            //หมอ
            setCharacterModel("Doctor", x_Coordinate, z_Coordinate, pix);
            characterObject.AddComponent<Doctor>();
            setCharacterSprite("Doctor");
        }

        else if (((((typeColor["gold"].r - tolerancea) < pix.r) && (pix.r < (typeColor["gold"].r + tolerancea))) && (((typeColor["gold"].g - tolerancea) < pix.g) && (pix.g < (typeColor["gold"].g + tolerancea))) && (((typeColor["gold"].b - tolerancea) < pix.b) && (pix.b < (typeColor["gold"].b + tolerancea)))))
        {
            //ฮีโร่
            setCharacterModel("Hero", x_Coordinate, z_Coordinate, pix);
            characterObject.AddComponent<Hero>();
            setCharacterSprite("Hero");
        }

        else if (((((typeColor["olivedrab"].r - tolerancea) < pix.r) && (pix.r < (typeColor["olivedrab"].r + tolerancea))) && (((typeColor["olivedrab"].g - tolerancea) < pix.g) && (pix.g < (typeColor["olivedrab"].g + tolerancea))) && (((typeColor["olivedrab"].b - tolerancea) < pix.b) && (pix.b < (typeColor["olivedrab"].b + tolerancea)))))
        {
            //ปวดท้อง
            setCharacterModel("Stomachache", x_Coordinate, z_Coordinate, pix);
            characterObject.AddComponent<Stomachache>();
            setCharacterSprite("Stomachache");
        }

        else if (((((typeColor["darkcyan"].r - tolerancea) < pix.r) && (pix.r < (typeColor["darkcyan"].r + tolerancea))) && (((typeColor["darkcyan"].g - tolerancea) < pix.g) && (pix.g < (typeColor["darkcyan"].g + tolerancea))) && (((typeColor["darkcyan"].b - tolerancea) < pix.b) && (pix.b < (typeColor["darkcyan"].b + tolerancea)))))
        {
            //ปวดหัว
            setCharacterModel("Headache", x_Coordinate, z_Coordinate, pix);
            characterObject.AddComponent<Headache>();
            setCharacterSprite("Headache");
        }

        else if (((((typeColor["green"].r - tolerancea) < pix.r) && (pix.r < (typeColor["green"].r + tolerancea))) && (((typeColor["green"].g - tolerancea) < pix.g) && (pix.g < (typeColor["green"].g + tolerancea))) && (((typeColor["green"].b - tolerancea) < pix.b) && (pix.b < (typeColor["green"].b + tolerancea)))))
        {
            //น้ำมูกไหล
            setCharacterModel("RunnyNose", x_Coordinate, z_Coordinate, pix);
            characterObject.AddComponent<RunnyNose>();
            setCharacterSprite("RunnyNose");
        }

        else if (((((typeColor["lightsteelblue"].r - tolerancea) < pix.r) && (pix.r < (typeColor["lightsteelblue"].r + tolerancea))) && (((typeColor["lightsteelblue"].g - tolerancea) < pix.g) && (pix.g < (typeColor["lightsteelblue"].g + tolerancea))) && (((typeColor["lightsteelblue"].b - tolerancea) < pix.b) && (pix.b < (typeColor["lightsteelblue"].b + tolerancea)))))
        {
            //ติดเชื้อ
            setCharacterModel("Infect", x_Coordinate, z_Coordinate, pix);
            characterObject.AddComponent<Infect>();
            setCharacterSprite("Infect");
        }

        else if (((((typeColor["peru"].r - tolerancea) < pix.r) && (pix.r < (typeColor["peru"].r + tolerancea))) && (((typeColor["peru"].g - tolerancea) < pix.g) && (pix.g < (typeColor["peru"].g + tolerancea))) && (((typeColor["peru"].b - tolerancea) < pix.b) && (pix.b < (typeColor["peru"].b + tolerancea)))))
        {
            //อาการคัน
            setCharacterModel("Itching", x_Coordinate, z_Coordinate, pix);
            characterObject.AddComponent<Itching>();
            setCharacterSprite("Itching");
        }

        else if (((((typeColor["navajowhite"].r - tolerancea) < pix.r) && (pix.r < (typeColor["navajowhite"].r + tolerancea))) && (((typeColor["navajowhite"].g - tolerancea) < pix.g) && (pix.g < (typeColor["navajowhite"].g + tolerancea))) && (((typeColor["navajowhite"].b - tolerancea) < pix.b) && (pix.b < (typeColor["navajowhite"].b + tolerancea)))))
        {
            //สิว
            setCharacterModel("Acne", x_Coordinate, z_Coordinate, pix);
            characterObject.AddComponent<Acne>();
            setCharacterSprite("Acne");
        }

        else if (((((typeColor["palevioletred"].r - tolerancea) < pix.r) && (pix.r < (typeColor["palevioletred"].r + tolerancea))) && (((typeColor["palevioletred"].g - tolerancea) < pix.g) && (pix.g < (typeColor["palevioletred"].g + tolerancea))) && (((typeColor["palevioletred"].b - tolerancea) < pix.b) && (pix.b < (typeColor["palevioletred"].b + tolerancea)))))
        {
            //ปวดกล้ามเนื้อ
            setCharacterModel("MusclePain", x_Coordinate, z_Coordinate, pix);
            characterObject.AddComponent<MusclePain>();
            setCharacterSprite("MusclePain");
        }

        else if (((((typeColor["lightyellow"].r - tolerancea) < pix.r) && (pix.r < (typeColor["lightyellow"].r + tolerancea))) && (((typeColor["lightyellow"].g - tolerancea) < pix.g) && (pix.g < (typeColor["lightyellow"].g + tolerancea))) && (((typeColor["lightyellow"].b - tolerancea) < pix.b) && (pix.b < (typeColor["lightyellow"].b + tolerancea)))))
        {
            //เชื้อราที่ผิวหนัง
            setCharacterModel("SkinFungus", x_Coordinate, z_Coordinate, pix);
            characterObject.AddComponent<SkinFungus>();
            setCharacterSprite("SkinFungus");
        }

        else if (((((typeColor["mediumslateblue"].r - tolerancea) < pix.r) && (pix.r < (typeColor["mediumslateblue"].r + tolerancea))) && (((typeColor["mediumslateblue"].g - tolerancea) < pix.g) && (pix.g < (typeColor["mediumslateblue"].g + tolerancea))) && (((typeColor["mediumslateblue"].b - tolerancea) < pix.b) && (pix.b < (typeColor["mediumslateblue"].b + tolerancea)))))
        {
            //จอมมาร
            setCharacterModel("DemonLord", x_Coordinate, z_Coordinate, pix);
            characterObject.AddComponent<DemonLord>();
            setCharacterSprite("DemonLord");
        }
    }
}