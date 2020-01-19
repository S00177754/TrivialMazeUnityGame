using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoginPanelController : MonoBehaviour
{
    public TMP_InputField UsernameInput;
    public TMP_InputField PasswordInput;
    public TMP_Text ErrorText;

    private LoginController loginController;

    public void Login()
    {
        Player attempt = ApiHelper.GetPlayer(UsernameInput.text);

        if(attempt != null && loginController != null)
        {
            if(attempt.Password == PasswordInput.text)
            {
                loginController.LoggedIn = true;
                loginController.Username = UsernameInput.text;
            }
            else
            {
                ErrorText.text = "Incorrect Password.";
            }
        }
        else
        {
            ErrorText.text = "Player does not exist.";
        }
    }

    public void SetController(LoginController controller)
    {
        loginController = controller;
    }
}
