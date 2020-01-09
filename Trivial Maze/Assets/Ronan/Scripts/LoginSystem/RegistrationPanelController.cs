using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RegistrationPanelController : MonoBehaviour
{
    private LoginController loginController;

    public TMP_InputField UsernameInput;
    public TMP_InputField PasswordInput;
    public TMP_InputField ConfirmPasswordInput;

    public void Register()
    {
        if(PasswordInput.text == ConfirmPasswordInput.text)
        {
            ApiHelper.PostPlayer(UsernameInput.text, PasswordInput.text);
            loginController.LoggedIn = true;
        }
    }

    public void SetController(LoginController controller)
    {
        loginController = controller;
    }
}
