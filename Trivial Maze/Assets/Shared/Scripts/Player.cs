using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Guid PlayerID;

    public string Username;

    public string Password;

    public List<Message> SentMessages;
    public List<TimeScore> TimeScores;
}
