using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class LobbyMenuManager : MenuManager
{
    public GameObject P1Name;
    public GameObject P2Name;
    public GameObject P1NameButton;
    public GameObject P2NameButton;
    public GameObject P1NameInput;
    public GameObject P2NameInput;


    private GameManager manager;
    private LobbyManager lobbyManager;


   
    void Start()
    {
        if (!menuManager)
        {
            menuManager = this;
        }

        if (!manager)
        {
            manager = GameManager.GetManager();
        }
        if (!lobbyManager)
        {
            lobbyManager = manager.GetLobbyManager();
        }

        if(!manager)
        {
            Debug.LogError("Game manager not found!");
            return;
        }


        if(manager.GetPlayerNum() == 1)
        {
            P1NameButton.SetActive(true);
            P1NameInput.SetActive(true);
        }
        else if (manager.GetPlayerNum() == 2)
        {
            P2NameButton.SetActive(true);
            P2NameInput.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(lobbyManager.CheckConnection())
        {
            if (manager.GetPlayerNum() == 1)
            {
                P1Name.GetComponent<TMP_Text>().text = lobbyManager.GetName();

                //todo, get P2 Name
            }
            else
            {
                P2Name.GetComponent<TMP_Text>().text = lobbyManager.GetName();

                //todo, get P1 Name
            }
        }

    }


    public void OnNameChangeButton()
    {
        string newName;

        if (manager.GetPlayerNum() == 1)
        {
            newName = P1NameInput.GetComponent<TMP_InputField>().text;
        }
        else 
        {
            newName = P2NameInput.GetComponent<TMP_InputField>().text;
        }

        if(string.IsNullOrEmpty(newName))
        {
            return;
        }

        lobbyManager.ChangeName(newName);
    }
}
