using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneSystem : MonoBehaviour
{
    public SaveManager sm;
    public KeepPlayingButton kpb;
    public GameStartButton gsb;
    // Start is called before the first frame update
    void Start()
    {
        sm.Load();
        kpb.CanChange = sm.state.storyOrder != -1;
        gsb.firstPlay = sm.state.storyOrder == -1;
    }

}
