using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UI_Information : UIBehaviour
{
    public Image RoomImage;
    public Text RoomNameText;
    public Text PlayerNumber;
    public Button LeaveButton;


    // Use this for initialization
    public void SetRoomInfo (Room room)
    {
        RoomNameText.text = room.Name;
        PlayerNumber.text = room.PlayerCount.ToString() + " / " + room.MaxPlayers.ToString();

    }

    public void AddLeaveButtonEvent(UnityAction callback)
    {
        LeaveButton.onClick.AddListener(callback);
    }
}
