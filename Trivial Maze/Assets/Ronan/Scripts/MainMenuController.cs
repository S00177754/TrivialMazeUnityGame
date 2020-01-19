using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject MenuItems;
    public GameObject LoginScreen;

    // Start is called before the first frame update
    void Start()
    {
        LoginScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (LoginScreen.GetComponent<LoginController>().LoggedIn)
        {
            LoginScreen.SetActive(false);
        }
    }

    public void SinglePlayerStart()
    {
        if (LoginScreen.GetComponent<LoginController>().LoggedIn)
        {
            MenuItems.SetActive(false);
            LoginScreen.SetActive(true);

            LoginScreen.GetComponent<LoginController>().SwitchToLogin();
        }
    }

    public void MultiplayerStart()
    {
        if (LoginScreen.GetComponent<LoginController>().LoggedIn)
        {
            MenuItems.SetActive(false);
            LoginScreen.SetActive(false);
        }
    }

    public void ViewLeaderboard()
    {
        if (LoginScreen.GetComponent<LoginController>().LoggedIn)
        {
            MenuItems.SetActive(false);
            LoginScreen.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void ReturnToMainMenu()
    {
        
    }
}
