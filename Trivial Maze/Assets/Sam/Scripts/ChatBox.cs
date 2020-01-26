using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChatBox : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public CanvasGroup canvasGroup;
    public InputField txtMessage;
    public string Username = "";
    public GameObject ChatMessage;

    public SignalRController signalRController;
    public UnityMainThreadDispatcher dispatcher;
    public RectTransform content;

    void Start()
    {
        signalRController.OnLoggedIn += SignalRController_OnLoggedIn;
        signalRController.OnUserJoined += SignalRController_OnUserJoined;
        signalRController.OnUserLeft += SignalRController_OnUserLeft;
        signalRController.OnMessageRecieved += SignalRController_OnMessageRecieved;
    }

    private IEnumerator CreateChatBox(string message)
    {
        GameObject textGameObject = Instantiate(ChatMessage, content.transform);
        TextMeshProUGUI textControl = textGameObject.GetComponent<TextMeshProUGUI>();
        textControl.text = message;

        yield return null;
    }

    private void SignalRController_OnMessageRecieved(string value)
    {
        UnityMainThreadDispatcher.Instance().Enqueue(CreateChatBox(value));
    }

    private void SignalRController_OnUserLeft(string value)
    {
        UnityMainThreadDispatcher.Instance().Enqueue(CreateChatBox(value + " has left."));
    }

    private void SignalRController_OnUserJoined(string value)
    {
        UnityMainThreadDispatcher.Instance().Enqueue(CreateChatBox(value + " has joined."));
    }

    private void SignalRController_OnLoggedIn()
    {
        UnityMainThreadDispatcher.Instance().Enqueue(CreateChatBox("LoggedIn"));
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        CancelInvoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Invoke("HideChatBox", 3);
    }

    private void HideChatBox()
    {
        canvasGroup.alpha = 0;
    }

    public void SendChatMessage()
    {
        if (txtMessage != null)
        {
            if (!string.IsNullOrEmpty(txtMessage.text))
            {
                signalRController.SendChatMessage(txtMessage.text);
                StartCoroutine(CreateChatBox(txtMessage.text));

                txtMessage.text = "";
            }
        }
    }


}
