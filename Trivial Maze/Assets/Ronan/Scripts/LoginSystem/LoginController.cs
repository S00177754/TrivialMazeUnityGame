using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginController : MonoBehaviour
{
    //UI Panels
    public GameObject LoginPanel;
    public GameObject SignUpPanel;

    // Start is called before the first frame update
    void Start()
    {
        SwitchToLogin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchToLogin()
    {
        LoginPanel.SetActive(true);
        SignUpPanel.SetActive(false);
    }

    public void SwitchToSignUp()
    {
        SignUpPanel.SetActive(true);
        LoginPanel.SetActive(false);
    }
}
