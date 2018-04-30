using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class UI_RoomList : UIBehaviour
{
    public Button UpdateButton;

    private List<Slot_Room> _roomButtonList;
    
    // Use this for initialization
    protected override void Awake ()
    {
        _roomButtonList = new List<Slot_Room>();
        _roomButtonList = this.transform.GetComponentsInChildren<Slot_Room>().ToList();
    }
    
    public void AddClickButtonEvent(UnityAction<Slot_Room> joinRoomEvent, UnityAction updateEvent)
    {
        _roomButtonList.ForEach((room)=> { room.RoomButton.onClick.AddListener(()=> { joinRoomEvent(room); }); });
        UpdateButton.onClick.AddListener(updateEvent);
    }

    public void SetRoomListInfo(RoomInfo[] infos)
    {
        for (int i = 0, roomCount = _roomButtonList.Count; i < roomCount; i++)
        {
            bool isNoInfoForUiToShow = i >= infos.Length;
            if (isNoInfoForUiToShow)
            {
                _roomButtonList[i].gameObject.SetActive(false);
                continue;
            }

            _roomButtonList[i].SetRoomInfo(infos[i]);
            _roomButtonList[i].gameObject.SetActive(true);
        }
    }
}
