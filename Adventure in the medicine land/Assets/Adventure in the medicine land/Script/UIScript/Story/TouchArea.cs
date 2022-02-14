using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchArea : MonoBehaviour
{

    [SerializeField]
    private StorySystem ss;
    [SerializeField]
    private AudioSource TouchAudio;

    // Start is called before the first frame update
    void Start()
    {
        ss = GameObject.Find("StorySystem").GetComponent<StorySystem>();
    }

    public void NextDialog()
    {
        TouchAudio.Play();
        ss.Index++;
    }
}
