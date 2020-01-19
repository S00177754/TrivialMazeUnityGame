using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TimeScore
{
    public int ID;
    public double Time;
    public string PlayerUsername;
    public Player Player;
}

[Serializable]
public class TimeScoreCollection
{
    public TimeScore[] scores;
}
