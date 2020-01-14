using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public GameObject StartPanel;
    public TMP_Text TimerText;

    private float Timer;
    private bool isTimerActive;

    // Start is called before the first frame update
    void Start()
    {
        Timer = 0f;
        TimerText.text = "Timer: " + Mathf.Round(Timer);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerActive)
        {
            Timer += Time.deltaTime;
            TimerText.text = "Timer: " + Mathf.Round(Timer);
        }
    }

    public void StartTimer()
    {
        isTimerActive = true;
        StartPanel.SetActive(false);
    }

    public void ResetTimer()
    {
        Timer = 0f;
    }

    public void StopTimer()
    {
        isTimerActive = false;
    }

    public void PostTimeToAPI()
    {

    }
}
