using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager menuManager;

    public GameObject SingleplayerButton;
    public GameObject MultiplayerButton;
    public GameObject OptionsButton;
    public GameObject ExitButton;

    public GameObject HostButton;
    public GameObject JoinButton;
    public GameObject GameNameText;
    public GameObject GameFailText;
    public TMP_Text GameNameInput;

    public static MenuManager GetMenuManager()
    {
        return menuManager;
    }


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

        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {

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

        if(string.IsNullOrEmpty(inputName))
        {
            GameFailText.SetActive(true);

            GameFailText.GetComponent<TMP_Text>().text = "Must Enter A Name";
        }
    }

    public void OnJoinPress()
    {


    }
}
