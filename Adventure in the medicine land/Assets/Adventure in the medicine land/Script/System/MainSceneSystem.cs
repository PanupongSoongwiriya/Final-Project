using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneSystem : MonoBehaviour
{
    [SerializeField]
    private SaveManager sm;
    [SerializeField]
    private KeepPlayingButton kpb;
    [SerializeField]
    private GameStartButton gsb;
    [SerializeField]
    private AudioSource BGM;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 120;
        sm.Load();
        kpb.CanChange = sm.state.storyOrder != -1 && sm.state.storyOrder != 4;
        gsb.firstPlay = sm.state.storyOrder == -1 || sm.state.storyOrder == 4;
        gsb.sm = sm;
        BGM.Play();
    }

}
