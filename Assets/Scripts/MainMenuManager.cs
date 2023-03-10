using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class MainMenuManager : MenuManager
{
    public GameObject SingleplayerButton;
    public GameObject MultiplayerButton;
    public GameObject OptionsButton;
    public GameObject ExitButton;

    public GameObject HostButton;
    public GameObject JoinButton;
    public GameObject GameNameText;
    public GameObject GameFailText;
    public TMP_Text GameNameInput;

    private GameManager manager;
    private LobbyManager lobbyManager;

    void Start()
    {
        if (!menuManager)
        {
            menuManager = this;
        }

        HostButton.SetActive(false);
        JoinButton.SetActive(false);
        GameNameText.SetActive(false);
        GameFailText.SetActive(false);
    }

    void Update()
    {
        if (!manager)
        {
            manager = GameManager.GetManager();
        }
        if (!lobbyManager)
        {
            lobbyManager = manager.GetLobbyManager();
        }
    }

    public void OnSingleplayerPress()
    {

    }

    public void OnMultiplayerPress()
    {
        MultiplayerButton.SetActive(false);

        HostButton.SetActive(true);
        JoinButton.SetActive(true);
        GameNameText.SetActive(true);
    }

    public void OnOptionsPress()
    {

    }

    public void OnExitPress()
    {
        Application.Quit();
    }

    public void OnHostPress()
    {
        string inputName = GameNameText.GetComponent<TMP_InputField>().text;

        if (string.IsNullOrEmpty(inputName))
        {
            GameFailText.SetActive(true);

            GameFailText.GetComponent<TMP_Text>().text = "Must Enter A Name";
        }
        else
        {
            lobbyManager.HostGame(inputName);
        }
    }

    public void OnJoinPress()
    {


    }
}
