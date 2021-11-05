[System.Serializable]
public class CEvent
{
    public int id;
    public string name;
    public string path;
}

[System.Serializable]
public class CRoot
{
    public CEvent[] events;
}