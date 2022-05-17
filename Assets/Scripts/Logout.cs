using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logout : MonoBehaviour
{

    public void ResetTheApp()
    {
        LocalModeSelection.modeSelected = "";
        LocalTaskSelection.taskSelected = "";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
