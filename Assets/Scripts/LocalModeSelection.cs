using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalModeSelection : MonoBehaviour
{
    public GameObject FBXModeObj;
    public GameObject XsensModeObj;

    public GameObject mainCamera;

    public GameObject Canvas_LocalModeSelection;
    public GameObject Canvas_LocalTaskSelection;

    public static string modeSelected;
    public static bool isVideoMode;

    private void Start()
    {
        isVideoMode = false;
    }

    public void FBXModeSelect()
    {
        modeSelected = "FBXMode";
        FBXModeObj.SetActive(true);
        LocalAnimControl.character = FBXModeObj;

        CameraFollow.staticTarget = FBXModeObj.transform;

        mainCamera.SetActive(true);

        Canvas_LocalModeSelection.SetActive(false);
        Canvas_LocalTaskSelection.SetActive(true);
    }

    public void XsensModeSelect()
    {
        modeSelected = "XsensMode";
        XsensModeObj.SetActive(true);
        LocalAnimControl.character = XsensModeObj;

        CameraFollow.staticTarget = XsensModeObj.transform;

        mainCamera.SetActive(true);

        Canvas_LocalModeSelection.SetActive(false);
        Canvas_LocalTaskSelection.SetActive(true);
    }

    public void VideoModeSelect()
    {
        modeSelected = "VideoMode";
        isVideoMode = true;

        Canvas_LocalModeSelection.SetActive(false);
        Canvas_LocalTaskSelection.SetActive(true);
    }

}
