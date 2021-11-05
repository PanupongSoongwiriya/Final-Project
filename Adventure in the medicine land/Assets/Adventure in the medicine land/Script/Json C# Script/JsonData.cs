[System.Serializable]
public class dialog
{
    public int id;
    public string actor;
    public string val;
    public string sfx;
}

[System.Serializable]
public class Chapter
{
    public int chapter;
    public dialog[] dialog;
}

[System.Serializable]
public class JsonData
{
    public Chapter[] story;
}