////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:       ScoreScript.cs
/// Author:         Chris Johnson
/// Date Created:   12/10/2021
/// Brief:  All functions relating to the menu management
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// All functions relating to the menu management
/// </summary>
public class MenuManager : MonoBehaviour
{
    //script references 
    SettingsMenu settingsMenuScript;

    //object references 
    [SerializeField]
    GameObject settingsObject;
    [Header("Menus")]
    [SerializeField]
    GameObject m_mainMenu = null;
    [SerializeField]
    GameObject m_inGame = null;
    [SerializeField]
    GameObject m_settings = null;
    [SerializeField]
    GameObject m_pause = null;

    //
    [Header("UI start on main menu")]
    [SerializeField]
    bool UIStartMain = true;

    //Menus
    enum Menu
    {
        MAIN_MENU,
        INGAME,
        SETTINGS,
        PAUSE
    };


    // Start is called before the first frame update
    void Start()
    {
        if (UIStartMain == true)
        {
            MenuMain();
        }
        else
        {
            MenuInGame();
        }

        settingsMenuScript = settingsObject.GetComponent<SettingsMenu>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// set the arg menu to active
    /// </summary>
    /// <param a menu to change to="a_currentMenu"></param>
    private void UpdateMenu(Menu a_currentMenu)
    {
        //hide all of the attached menus
        HideAllMenus();
        //show the current menu
        switch (a_currentMenu)
        {
            case Menu.MAIN_MENU:
                m_mainMenu.SetActive(true);
                break;
            case Menu.INGAME:
                m_inGame.SetActive(true);
                break;
            case Menu.SETTINGS:
                m_settings.SetActive(true);
                break;
            case Menu.PAUSE:
                m_pause.SetActive(true);
                break;
            default:
                break;
        }

    }

    /// <summary>
    /// update the menu to in game
    /// </summary>
    public void MenuMain()
    {
        UpdateMenu(Menu.MAIN_MENU);
    }


    /// <summary>
    /// update the menu to in game
    /// </summary>
    public void MenuInGame()
    {
        UpdateMenu(Menu.INGAME);
    }

    /// <summary>
    /// update the menu to settings
    /// </summary>
    public void MenuSettings()
    {
        UpdateMenu(Menu.SETTINGS);
        settingsMenuScript.DisplayControlPage();
    }

    /// <summary>
    /// update the menu to pause
    /// </summary>
    public void MenuPause()
    {
        UpdateMenu(Menu.PAUSE);
    }


    /// <summary>
    /// set all of the menus attached to hidden
    /// </summary>
    private void HideAllMenus()
    {
        m_mainMenu.SetActive(false);
        m_inGame.SetActive(false);
        m_settings.SetActive(false);
        m_pause.SetActive(false);
    }

    /// <summary>
    /// exit the aplication
    /// </summary>
    public void ExitApplication()
    {
        Application.Quit();
        Debug.Log("Application.Quit(); has been run");
    }

}
