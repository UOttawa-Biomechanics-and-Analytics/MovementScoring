using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LocalVideoController : MonoBehaviour
{
    public string videoFolderPath;

    public GameObject videoPlayerTopLeft;
    public GameObject videoPlayerTopRight;
    public GameObject videoPlayerBottomLeft;
    public GameObject videoPlayerBottomRight;

    private int currVideoIndex;
    private int taskVideoCount;

    private bool _updateVideoPathFlag;

    // Start is called before the first frame update
    void OnEnable()
    {
        //Application.dataPath is the path of the Assests folder
        videoFolderPath = Application.dataPath+"/Videos/SampleVideos/";

        _updateVideoPathFlag = true;

        currVideoIndex = 1;
        taskVideoCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (_updateVideoPathFlag == true && LocalTaskSelection.taskSelectedFlag == true)
        {
            videoPlayerTopLeft.GetComponent<VideoPlayer>().url = videoFolderPath + LocalTaskSelection.taskSelected + currVideoIndex.ToString() + "_TopLeft.mp4";
            videoPlayerTopRight.GetComponent<VideoPlayer>().url = videoFolderPath + LocalTaskSelection.taskSelected + currVideoIndex.ToString() + "_TopRight.mp4";
            videoPlayerBottomLeft.GetComponent<VideoPlayer>().url = videoFolderPath + LocalTaskSelection.taskSelected + currVideoIndex.ToString() + "_BottomLeft.mp4";
            videoPlayerBottomRight.GetComponent<VideoPlayer>().url = videoFolderPath + LocalTaskSelection.taskSelected + currVideoIndex.ToString() + "_BottomRight.mp4";

            _updateVideoPathFlag = false;
        }
        if (LocalModeSelection.modeSelected == "VideoMode")
            GameObject.Find("AnimationName").GetComponent<UnityEngine.UI.Text>().text = LocalTaskSelection.taskSelected + currVideoIndex.ToString();
    }


    public void PlayVideo()
    {
        if (LocalModeSelection.modeSelected == "VideoMode")
        {
            videoPlayerTopLeft.GetComponent<VideoPlayer>().Play();
            videoPlayerTopRight.GetComponent<VideoPlayer>().Play();
            videoPlayerBottomLeft.GetComponent<VideoPlayer>().Play();
            videoPlayerBottomRight.GetComponent<VideoPlayer>().Play();
        }
    }

    public void PlayVideoNext()
    {
        if (currVideoIndex < taskVideoCount)
        {
            currVideoIndex++;

            _updateVideoPathFlag = true;
        }

    }

    public void PlayVideoPrevious()
    {
        if (currVideoIndex > 1)
        {
            currVideoIndex--;

            _updateVideoPathFlag = true;
        }
    }


}
