using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChatBox : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public InputField txtMessage;
    public CanvasGroup canvasGroup;
    public GameObject chatMessage;
    public string Username = "";

    //NEEDS INITIALISED
    Player CurrentPlayer;

    void Start()
    {
        //Setup player
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        canvasGroup.alpha = 1;
        CancelInvoke("HideChatBox");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Invoke("HideChatBox", 3f);

    }

    void HideChatBox()
    {
        canvasGroup.alpha = 0;
    }

    //Call when button pressed or enter button pressed
    public void SendChatMessage()
    {
        if(txtMessage != null)
        {
            if(!string.IsNullOrEmpty(txtMessage.text))
            {
                //SEND TO SERVER
                Message newMessage = new Message
                {
                    //Add player and PlayerID
                    DateSent = DateTime.Now,
                    MessageText = txtMessage.text
                };
                string json = JsonUtility.ToJson(newMessage);
                ApiHelper.PostDataToAPI("Message", json);

                Debug.Log(newMessage);
                txtMessage.text = null;
            }
        }

    }
}
