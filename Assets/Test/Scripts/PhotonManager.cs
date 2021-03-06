﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhotonManager : Photon.PunBehaviour
{
    public static PhotonManager instance;

    void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;

        // 讓 PUN 能自動同步載入場景, 可以避免在載入場景初始化時發生一些網路問題.
        PhotonNetwork.automaticallySyncScene = true;
    }

    void Start()
    {
        //InvokeRepeating("UpdateStatus", 0, 1f);

        Connect();
    }

    void Connect()
    {
        //PhotonNetwork.ConnectToRegion(CloudRegionCode.asia, "PhotonTest_1.0");
        // 與 Photon Cloud/Server 建立起連線,可以用字串方式設定須要連線的遊戲版本
        if (!PhotonNetwork.ConnectUsingSettings("PUN_PhotonCloud_1.0"))
        {
            Debug.Log("Connect Using Settings Failed...");
        }
        
    }

    void UpdateStatus()
    {
        string status = PhotonNetwork.connectionStateDetailed.ToString();
        int ping = PhotonNetwork.GetPing();
        Debug.Log(status + ", " + ping + "ms");
    }

    public override void OnConnectedToPhoton()
    {
        Debug.Log("Connecting....");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connect To Master Success!");

    }
}