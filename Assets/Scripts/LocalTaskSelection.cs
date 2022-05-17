using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalTaskSelection : MonoBehaviour
{
    public static string taskSelected;
    public static bool taskSelectedFlag;

    public GameObject Canvas_LocalTaskSelection;
    public GameObject VideoComponents;
    public GameObject LocalVideoController;

    private void Start()
    {
        taskSelected = "";
        taskSelectedFlag = false;
    }

    public void LhopSelect()
    {
        taskSelected = "lhop";
        taskSelectedFlag = true;
        Canvas_LocalTaskSelection.SetActive(false);

        if (LocalModeSelection.modeSelected == "VideoMode")
        {
            VideoComponents.SetActive(true);
            LocalVideoController.SetActive(true);
        }
    }

    public void LungeSelect()
    {
        taskSelected = "lunge";
        taskSelectedFlag = true;
        Canvas_LocalTaskSelection.SetActive(false);

        if (LocalModeSelection.modeSelected == "VideoMode")
        {
            VideoComponents.SetActive(true);
            LocalVideoController.SetActive(true);
        }
    }

    public void VertJumpSelect()
    {
        taskSelected = "vertJump";
        taskSelectedFlag = true;
        Canvas_LocalTaskSelection.SetActive(false);

        if (LocalModeSelection.modeSelected == "VideoMode")
        {
            VideoComponents.SetActive(true);
            LocalVideoController.SetActive(true);
        }
    }

}
