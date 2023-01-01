using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager manager;
    public MenuManager menuManager;
    public LobbyManager lobbyManager;

    public static GameManager GetManager()
    {
        return manager;
    }


    void Start()
    {
        if(!manager)
        {
            manager = this;
        }

        DontDestroyOnLoad(this.gameObject);
        lobbyManager.ConenctToOnline();
    }



    void Update()
    {
        if(!menuManager)
        {
            menuManager = MenuManager.GetMenuManager();
        }
        if (!lobbyManager)
        {
            lobbyManager = LobbyManager.GetLobbyManager();
        }
    }

    public LobbyManager GetLobbyManager()
    {
        return lobbyManager;
    }

    public MenuManager GetMenuManager()
    {
        return menuManager;
    }
}
