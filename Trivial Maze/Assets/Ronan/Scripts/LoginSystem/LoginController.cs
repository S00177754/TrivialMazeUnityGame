﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginController : MonoBehaviour
{
    //UI Panels
    public GameObject LoginPanel;
    public GameObject SignUpPanel;

    public bool LoggedIn;
    public string Username;

    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    void Start()
    {
        LoggedIn = false;

        LoginPanel.GetComponent<LoginPanelController>().SetController(this);
        SignUpPanel.GetComponent<RegistrationPanelController>().SetController(this);

        LoginPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(LoggedIn == true)
        {
            Debug.Log("DisablePanels");
            DisablePanels();
        }
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

    public void DisablePanels()
    {
        SignUpPanel.SetActive(false);
        LoginPanel.SetActive(false);
    }
}
