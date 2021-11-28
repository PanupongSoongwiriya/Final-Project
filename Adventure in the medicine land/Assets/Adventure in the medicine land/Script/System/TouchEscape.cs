using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEscape : MonoBehaviour
{
    [SerializeField]
    private float firstTuochTime;

    [SerializeField]
    private float timer = 0.0f;

    [SerializeField]
    private float timeDelay = 1f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float seconds = timer % 60;
        // Make sure user is on Android platform
        if (Application.platform == RuntimePlatform.Android)
        {
            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (firstTuochTime == 0)
                {
                    firstTuochTime = seconds;
                }else if (timeDelay > Mathf.Abs(firstTuochTime - seconds))
                {
                    firstTuochTime = 0;
                    //Quit the application
                    Application.Quit();
                }
                else
                {
                    firstTuochTime = 0;
                }
            }
        }
    }
}
