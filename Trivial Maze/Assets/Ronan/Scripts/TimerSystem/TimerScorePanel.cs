using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScorePanel : MonoBehaviour
{
    public TMP_Text Position;
    public TMP_Text Username;
    public TMP_Text TimeScore;

    public void SetDetails(TimeScore timeScore)
    {
        Username.text = timeScore.PlayerName;
        TimeScore.text = timeScore.Time.ToString();
    }

    public void SetPosition(int position)
    {
        Position.text = position.ToString();
    }
}
