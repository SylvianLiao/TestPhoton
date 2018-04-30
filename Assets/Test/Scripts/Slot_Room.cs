using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot_Room : UIBehaviour
{

    public Button RoomButton;
    public Text NameText;
    public Text PlayerNumber;

    public string RoomName { get{ return _roomInfo.Name; } }

    private RoomInfo _roomInfo;

    public void SetRoomInfo(RoomInfo info)
    {
        _roomInfo = info;
        NameText.text = info.Name;
        PlayerNumber.text = info.PlayerCount.ToString() + " / " + info.MaxPlayers.ToString();
    }
}
