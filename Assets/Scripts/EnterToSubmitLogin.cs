using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnterToSubmitLogin : MonoBehaviour
{
    //public Button Proceed;
    public GameObject loginProceedButton;

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<InputField>().textComponent.text.Length > 0 && Input.GetKeyDown(KeyCode.Return))
        {
            loginProceedButton.GetComponent<Button>().onClick.Invoke();
        }
        
    }
}
