using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{

    public static LobbyManager lobbyManager;

    private string gameVersion = ".01";


    void Start()
    {
        if(!lobbyManager)
        {
            lobbyManager = this;
        }
    }

    public static LobbyManager GetLobbyManager()
    {
        return lobbyManager;
    }

    public void HostGame()
    {

    }

    public void JoinGame()
    {

    }
}
