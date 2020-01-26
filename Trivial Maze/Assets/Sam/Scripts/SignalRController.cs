using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.AspNet.SignalR.Client;
using System;

public class SignalRController : MonoBehaviour
{
    public string hubServerAddress = "https://localhost:44342/";
    public string hubName = "ChatHub";
    public bool isConnected = false;
    public bool isLoggedIn = false;

    private HubConnection connection;
    public IHubProxy hubProxy;

    public string username = "NanoPulse";

    void Awake()
    {
        ConnectToChatHub();
    }

    void ConnectToChatHub()
    {
        if (!string.IsNullOrEmpty(hubServerAddress) && !string.IsNullOrEmpty(hubName))
        {
            connection = new HubConnection(hubServerAddress);
            hubProxy = connection.CreateHubProxy(hubName);

            //Register local methods with the proxy 
            hubProxy.On("LoggedIn", new Action(LoggedIn));
            hubProxy.On("UserJoined", new Action<string>(UserJoined));
            hubProxy.On("UserLeft", new Action<string>(UserLeft));
            hubProxy.On("RecieveMessage", new Action<string, string>(MessageRecieved));

            try
            {
                connection.Start().Wait();
                isConnected = true;
            }
            catch
            {
                isConnected = false;
            }
        }
    }

    #region Methods called by server
    public event EmptyDelegate OnLoggedIn;
    public event StringDelegate OnUserJoined;
    public event StringDelegate OnUserLeft;
    public event StringDelegate OnMessageRecieved;
    void LoggedIn()
    {
        Debug.Log("Logged In!");
        isLoggedIn = true;
        OnLoggedIn?.Invoke();
    }

    void UserJoined(string username)
    {
        OnUserJoined?.Invoke(username);
    }

    void UserLeft(string username)
    {
        OnUserLeft?.Invoke(username);
    }

    void MessageRecieved(string username, string message)
    {
        OnMessageRecieved?.Invoke(username + " says " + message);
    }
    #endregion

    public void LogIn()
    {
        hubProxy.Invoke("Join", username);
    }

    public void SendChatMessage(string message)
    {
        if (isConnected && isLoggedIn)
        {
            hubProxy.Invoke("SendMessage", username, message);
        }
    }

    private void OnApplicationQuit()
    {
        if (isConnected && isLoggedIn)
        {
            hubProxy.Invoke("Leave", username);
        }
    }
}

public delegate void EmptyDelegate();
public delegate void StringDelegate(string value);
