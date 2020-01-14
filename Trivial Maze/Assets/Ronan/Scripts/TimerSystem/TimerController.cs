using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public TMP_Text TimerText;

    private float Timer;
    private bool isTimerActive;

    // Start is called before the first frame update
    void Start()
    {
        Timer = 0f;
        TimerText.text = "Timer: " + Timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerActive)
        {
            Timer += Time.deltaTime;
            TimerText.text = "Timer: " + Timer;
        }
    }

    public void StartTimer()
    {
        isTimerActive = true;
    }

    public void ResetTimer()
    {
        Timer = 0f;
    }

    public void StopTimer()
    {
        isTimerActive = false;
    }
}
