using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { set; get; }
    public SaveState state;

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        Instance = this;
        Load();

        //resetState();

        //Debug.Log(SaveSystem.Serialize<SaveState>(state));
    }

    public void Save()
    {
        PlayerPrefs.SetString("save", SaveSystem.Serialize<SaveState>(state));
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("save"))
        {
            state = SaveSystem.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
        }
        else
        {
            state = new SaveState();
            Save();
            Debug.Log("No save flie found");
        }
    }
    public void resetState()
    {
        state.storyOrder = -1;
        Save();
    }
}

