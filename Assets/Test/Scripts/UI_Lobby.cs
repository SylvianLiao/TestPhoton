using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UI_Lobby : UIBehaviour
{
    public Button CreateButton;
    public Button JoinButton;
    public Text RoomCreateNameText;

    private string _createRoomName { get { return RoomCreateNameText.text; } }

    // Use this for initialization
    public void AddButtonEvent (UnityAction<string> createEvent, UnityAction joinEvent)
    {
        CreateButton.onClick.AddListener(() => { createEvent(_createRoomName); });
        JoinButton.onClick.AddListener(joinEvent);
    }


}
