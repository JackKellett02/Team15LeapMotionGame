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
        
    }

    void GraphicsDropdownValueChanged(Dropdown a_dropdown)
    {

    }

    void WindowModeDropdownValueChanged(Dropdown a_dropdown)
    {

    }

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

    void FPSDropdownValueChanged(Dropdown a_dropdown)
    {

    }

    void VSyncToggleValueChanged(Toggle a_toggle)
    {

    }
}
