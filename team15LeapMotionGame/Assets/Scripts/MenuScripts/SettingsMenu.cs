////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:       SettingsMenu.cs
/// Author:         Chris Johnson
/// Date Created:   24/11/2021
/// Brief:  Functions to move between the settings pages
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField]
    GameObject ControlPage;
    [SerializeField]
    GameObject GraphicsPage;
    [SerializeField]
    GameObject AudioPage;
    [SerializeField]
    GameObject AccessibilityPage;

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        DisplayGraphicsPage();
    }


    /// <summary>
    /// show the control page in settings
    /// </summary>
    public void DisplayControlPage()
    {
        HideAllPages();
        ControlPage.SetActive(true);
    }

    /// <summary>
    /// show the graphics page in settings
    /// </summary>
    public void DisplayGraphicsPage()
    {
        HideAllPages();
        GraphicsPage.SetActive(true);
    }

    /// <summary>
    /// show the audio page in settings
    /// </summary>
    public void DisplayAudioPage()
    {
        HideAllPages();
        AudioPage.SetActive(true);
    }

    /// <summary>
    /// show the accessibility page in settings
    /// </summary>
    public void DisplayAccessibilityPage()
    {
        HideAllPages();
        AccessibilityPage.SetActive(true);
    }

    /// <summary>
    /// hide all settigns pages
    /// </summary>
    public void HideAllPages()
    {
        ControlPage.SetActive(false);
        GraphicsPage.SetActive(false);
        AudioPage.SetActive(false);
        AccessibilityPage.SetActive(false);
    }

}
