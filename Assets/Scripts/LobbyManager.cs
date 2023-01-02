using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{

    public static LobbyManager lobbyManager;

    private string gameVersion = ".01";


    void Start()
    {
        if(!lobbyManager)
        {
            lobbyManager = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Awake()
    {

        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public static LobbyManager GetLobbyManager()
    {
        return lobbyManager;
    }

    public void HostGame(string gameName)
    {
        if (PhotonNetwork.IsConnected)
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.IsVisible = true;
            roomOptions.MaxPlayers = 4;
            PhotonNetwork.CreateRoom(gameName, roomOptions, TypedLobby.Default);
        }
        else
        {
            Debug.Log("Not connected to online service");
        }
    }

    public void JoinGame(string gameName)
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRoom(gameName);
        }
        else
        {
            Debug.Log("Not connected to online service");
        }
    }

    public void ConenctToOnline()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = gameVersion;
    }

    public override void OnCreatedRoom()
    {
        //Go to lobby screen

        PhotonNetwork.LoadLevel("LobbyMenu");
        
    }

    public void ChangeName(string newName)
    {
        if(string.IsNullOrEmpty(newName))
        {
            return;
        }

        photonView.Owner.NickName = newName;
    }

    public string GetName()
    {

        return photonView.Owner.NickName;
    }

    public bool CheckConnection()
    {

        return PhotonNetwork.IsConnected;
    }

}
