using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitscreenController : MonoBehaviour
{
    public bool IsMultiplayer;
    public PlayerController Player1; 
    public PlayerController Player2;
    public GameObject GO_PlayerTwo;

    // Start is called before the first frame update
    void Start()
    {
        IsMultiplayer = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsMultiplayer)
        {
            ReturnToPlayerOne();
        }
        else
        {
            ActivateSplitscreen();
        }
    }

    public void ActivateSplitscreen()
    {
        GO_PlayerTwo.SetActive(true);

        Player1.SwitchToSplitCamera(0f);
        Player2.SwitchToSplitCamera(0.5f);
    }

    public void ReturnToPlayerOne()
    {
        Player1.SwitchToSingleCamera();
        GO_PlayerTwo.SetActive(false);
    }
}
