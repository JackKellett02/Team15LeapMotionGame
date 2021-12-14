////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:       GraphicsSettings.cs
/// Author:         Chris Johnson
/// Date Created:   24/11/2021
/// Brief:  Functions relating to the graphics settings page
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsSettings : MonoBehaviour
{
    [SerializeField]
    Dropdown GraphicsDropdown;
    [SerializeField]
    Dropdown WindowModeDropdown;
    [SerializeField]
    Dropdown AntiAliasingDropdown;
    [SerializeField]
    Dropdown FPSDropdown;
    [SerializeField]
    Toggle VSyncToggle;

    int targetFramerate= 30;

    void Awake()
    {
        updateVsync();
    }

    // Start is called before the first frame update
    void Start()
    {
        GraphicsDropdown.onValueChanged.AddListener(delegate { GraphicsDropdownValueChanged(GraphicsDropdown); });
        WindowModeDropdown.onValueChanged.AddListener(delegate { WindowModeDropdownValueChanged(WindowModeDropdown); });
        AntiAliasingDropdown.onValueChanged.AddListener(delegate { AntiAliasingDropdownValueChanged(AntiAliasingDropdown); });
        FPSDropdown.onValueChanged.AddListener(delegate { FPSDropdownValueChanged(FPSDropdown); });
        VSyncToggle.onValueChanged.AddListener(delegate { VSyncToggleValueChanged(VSyncToggle); });
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.targetFrameRate != targetFramerate)
        {
            Application.targetFrameRate = targetFramerate;
        }
    }

    void GraphicsDropdownValueChanged(Dropdown a_dropdown)
    {
        
    }

    /// <summary>
    /// update the window mode to selected
    /// </summary>
    void WindowModeDropdownValueChanged(Dropdown a_dropdown)
    {
        if (a_dropdown.value == 0)
        {
            Screen.fullScreen = true;
        }
        else if (a_dropdown.value == 1)
        {
            Screen.fullScreen = false;
        }

    }

    /// <summary>
    /// set the anti aliasing to selected mode
    /// </summary>
    void AntiAliasingDropdownValueChanged(Dropdown a_dropdown)
    {

        if (a_dropdown.value == 1)
        {
            QualitySettings.antiAliasing = 2;
        }
        else if (a_dropdown.value == 2)
        {
            QualitySettings.antiAliasing = 4;
        }
        else if (a_dropdown.value == 3)
        {
            QualitySettings.antiAliasing = 8;
        }
        else if (a_dropdown.value == 4)
        {
            QualitySettings.antiAliasing = 16;
        }
        else 
        {
            QualitySettings.antiAliasing = 0;
        }

        Debug.Log(a_dropdown.value + " selected");
    }

    /// <summary>
    /// update the target fps to selected 
    /// </summary>
    /// <param fps dropdown="a_dropdown"></param>
    void FPSDropdownValueChanged(Dropdown a_dropdown)
    {
        if (a_dropdown.value == 0)
        {
            targetFramerate = 999;
        }
        if (a_dropdown.value == 1)
        {
            targetFramerate = 15;
        }
        else if (a_dropdown.value == 2)
        {
            targetFramerate = 30;
        }
        else if (a_dropdown.value == 3)
        {
            targetFramerate = 60;
        }
        else if (a_dropdown.value == 4)
        {
            targetFramerate = 90;
        }
        else if (a_dropdown.value == 5)
        {
            targetFramerate = 144;
        }
        updateVsync(); //to be safe
    }

    void VSyncToggleValueChanged(Toggle a_toggle)
    {
        updateVsync();
    }

    /// <summary>
    /// update if vsync is on or not
    /// </summary>
    void updateVsync()
    {
        if (VSyncToggle.isOn == true)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = targetFramerate;
        }
    }
}
