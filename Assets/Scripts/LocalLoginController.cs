using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalLoginController : MonoBehaviour
{

    public InputField username;
    public GameObject usernameOnDisplay;

    public GameObject Canvas_LocalLogin;
    public GameObject Canvas_LocalModeSelection;
    public GameObject GameScene;

    private void Start()
    {
        GameScene.SetActive(false);
        Canvas_LocalLogin.SetActive(true);

        username.Select();
        username.ActivateInputField();
    }

    public void Proceed()
    {
        if (username.text != "")
        {
            usernameOnDisplay.GetComponent<Text>().text = username.text;
            Canvas_LocalLogin.SetActive(false);
            Canvas_LocalModeSelection.SetActive(true);
            GameScene.SetActive(true);
        }
    }
}
