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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LoginScreen.GetComponent<LoginController>().LoggedIn)
        {
            gameObject.SetActive(false);
        }
    }

    public void SinglePlayerStart()
    {
        MenuItems.SetActive(false);
        LoginScreen.SetActive(true);

        LoginScreen.GetComponent<LoginController>().SwitchToLogin();
    }

    public void MultiplayerStart()
    {
        MenuItems.SetActive(false);
        LoginScreen.SetActive(false);
    }

    public void ViewLeaderboard()
    {
        MenuItems.SetActive(false);
        LoginScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TurnOffMainMenu()
    {
        MainMenuPanel.SetActive(false);
    }
}
