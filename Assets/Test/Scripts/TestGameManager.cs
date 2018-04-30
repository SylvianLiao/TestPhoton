using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TestGameManager : MonoBehaviour
{
    public UI_Lobby UiLobby;
    public UI_RoomList UiRoomList;
    public UI_Information UiInformation;

    private RoomOptions _roomOptions;

    public Text ConnectStatus;
    public Button BackButton;

    #region Init Function
    // Use this for initialization
    void Start()
    {
        SetPhotonUserID();

        ShowLobby();

        SetRoomOptions();

        PhotonNetwork.ConnectUsingSettings("1.0");
    }
    private void SetPhotonUserID()
    {
        PhotonNetwork.AuthValues = new AuthenticationValues(Random.Range(float.MinValue, float.MaxValue).ToString());
    }
    private void SetRoomOptions()
    {
        _roomOptions = new RoomOptions();
        _roomOptions.IsVisible = true;
        _roomOptions.MaxPlayers = 10;
    }
    #endregion

    public void SetStatusText(string status)
    {
        ConnectStatus.text = status;
    }

    private void ShowLobby()
    {
        UiLobby.gameObject.SetActive(true);
        UiInformation.gameObject.SetActive(false);
        UiRoomList.gameObject.SetActive(false);
        BackButton.gameObject.SetActive(false);

    }
    private void ShowRoomList()
    {
        UiLobby.gameObject.SetActive(false);
        UiInformation.gameObject.SetActive(false);
        UiRoomList.gameObject.SetActive(true);
        BackButton.gameObject.SetActive(true);
    }
    private void ShowRoomInfo()
    {
        UiLobby.gameObject.SetActive(false);
        UiInformation.gameObject.SetActive(true);
        UiRoomList.gameObject.SetActive(false);
        BackButton.gameObject.SetActive(false);

    }

    public void OnClickCreateRoom(Text roomNameText)
    {
        PhotonNetwork.CreateRoom(roomNameText.text, _roomOptions, null, null);
    }

    public void OnClickRoomList()
    {
        UpdateRoomList();
        ShowRoomList();
    }

    public void OnClickJoinRoom(Slot_Room room)
    {
        PhotonNetwork.JoinRoom(room.RoomName);
        UpdateRoomList();
    }

    public void OnClickUpdateRoom()
    {
        UpdateRoomList();
    }

    private void UpdateRoomList()
    {
        RoomInfo[] roomInfoAry = PhotonNetwork.GetRoomList();
        UiRoomList.SetRoomListInfo(roomInfoAry);
    }

    public void OnClickLeaveRoom()
    {
        if (PhotonNetwork.room == null)
            return;

        PhotonNetwork.LeaveRoom();
    }

    public void OnClickBackButton()
    {
        ShowLobby();
    }
    

    #region Photon Override Function
    public void OnConnectedToPhoton()
    {
        SetStatusText(PhotonNetwork.connectionStateDetailed.ToString());
    }
    /*
    public void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
    */
    public void OnJoinedLobby()
    {
        SetStatusText(PhotonNetwork.connectionStateDetailed.ToString());
        UpdateRoomList();
    }

    public void OnCreatedRoom()
    {
        SetStatusText(PhotonNetwork.connectionStateDetailed.ToString());

        UiInformation.SetRoomInfo(PhotonNetwork.room);

        ShowRoomInfo();
    }

    public void OnJoinedRoom()
    {
        SetStatusText(PhotonNetwork.connectionStateDetailed.ToString());

        UiInformation.SetRoomInfo(PhotonNetwork.room);

        ShowRoomInfo();
    }

    public void OnLeftRoom()
    {
        SetStatusText(PhotonNetwork.connectionStateDetailed.ToString());

        ShowRoomList();
    }

    public void OnPhotonCreateRoomFailed(object[] codeAndMsg)
    {
        SetStatusText(PhotonNetwork.connectionStateDetailed.ToString());

    }

    public void OnPhotonJoinRoomFailed(object[] codeAndMsg)
    {
        SetStatusText(PhotonNetwork.connectionStateDetailed.ToString());

    }

    public void OnLeftLobby()
    {
        SetStatusText(PhotonNetwork.connectionStateDetailed.ToString());

    }

    public void OnFailedToConnectToPhoton(DisconnectCause cause)
    {
        SetStatusText(cause.ToString());

    }
    #endregion
}
