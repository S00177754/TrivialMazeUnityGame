using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TimeScore
{
    public int ID;
    public double Time;
    public Guid PlayerID;
    public Player Player;
}
