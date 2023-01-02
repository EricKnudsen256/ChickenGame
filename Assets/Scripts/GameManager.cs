using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager manager;
    public MenuManager menuManager;
    public LobbyManager lobbyManager;

    private int playerNum = 1;
    private Character character;

    public enum Character
    {
        CHARACTER_CHICKEN,
        CHARACTER_FOX
    }

    private enum GameState
    {
        GAME_MAIN,
        GAME_LOBBY_LOCAL,
        GAME_LOBBY_ONLINE,
        GAME_LOCAL,
        GAME_ONLINE
    }



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

    public Character GetCharacter()
    {
        return this.character;
    }

    public void SetCharacter(Character character)
    {
        if (character != Character.CHARACTER_FOX || character != Character.CHARACTER_CHICKEN)
        {
            Debug.Log("Trying to set playerNum to " + character + ", can only be 0 or 1");
            return;
        }

        this.character = character;
    }

    public int GetPlayerNum()
    {
        return playerNum;
    }

    public void SetPlayerNum(int num)
    {
        if(num != 1 || num != 2)
        {
            Debug.Log("Trying to set playerNum to " + num + ", can only be 1 or 2");
            return;
        }

        playerNum = num;
    }
}
