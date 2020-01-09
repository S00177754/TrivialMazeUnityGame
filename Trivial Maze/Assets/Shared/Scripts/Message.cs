using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Message 
{
    public int ID;
    public Guid PlayerID;
    public string MessageText;
    public DateTime DateSent;
    public Player Player;
}
