using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public TimerController timerController;
    public MainMenuController mainMenuController;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetToStart()
    {
        GameObject[] gameobjects = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < gameobjects.Length; i++)
        {
            gameobjects[i].GetComponent<PlayerController>().ResetToStart();
            gameobjects[i].GetComponent<KeyCollecter>().ResetToStart();
        }

        timerController.ResetToStart();
    }

    public void ReturnToMenu()
    {
        ResetToStart();
        mainMenuController.ReturnToMenu();
    }
}
