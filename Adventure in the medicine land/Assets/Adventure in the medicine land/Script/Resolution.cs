using UnityEngine;
using System.Collections;

public class Resolution : MonoBehaviour
{
    public Camera mainCamera;
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        mainCamera = Camera.main;
        //float screenAspect = 1920/1080;
        mainCamera.aspect = 1.78f;
        Debug.Log("aspect: " + mainCamera.aspect);
    }
}