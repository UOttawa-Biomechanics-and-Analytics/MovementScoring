using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LocalScore : MonoBehaviour
{

    public void Score()
    {
        var score = GameObject.Find("ScoreInputField").GetComponent<UnityEngine.UI.InputField>().text;
        if (score != "") {
            string path = Application.persistentDataPath + "/score.txt";

            Debug.Log(path);

            StreamWriter writer = new StreamWriter(path, true);

            writer.WriteLine("Username: " + GameObject.Find("UsernameOnDisplay").GetComponent<UnityEngine.UI.Text>().text +
                "/" + "Mode: " + LocalModeSelection.modeSelected +
                "/" + "Animation: " + GameObject.Find("AnimationName").GetComponent<UnityEngine.UI.Text>().text +
                "/" + "Score :" + score +
                "/" + System.DateTime.Now.ToString("G"));

            writer.Close(); }
    }
}
