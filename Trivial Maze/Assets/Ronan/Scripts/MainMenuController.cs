using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject MenuItems;
    public GameObject LeaderboardPanel;
    public GameObject LoginScreen;
    public GameObject InstructionScreen;

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
            MainMenuPanel.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        InstructionScreen.SetActive(false);
    }

    public void MultiplayerStart()
    {
        if (LoginScreen.GetComponent<LoginController>().LoggedIn)
        {
            MainMenuPanel.SetActive(false);
            Time.timeScale = 0;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<SplitscreenController>().IsMultiplayer = true;
        }
    }

    public void ViewLeaderboard()
    {
        if (LoginScreen.GetComponent<LoginController>().LoggedIn)
        {
            MenuItems.SetActive(false);
            LeaderboardPanel.SetActive(true);
        }
    }

    public void ReturnToMenu()
    {
        MenuItems.SetActive(true);
        MainMenuPanel.SetActive(true);
        LeaderboardPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
