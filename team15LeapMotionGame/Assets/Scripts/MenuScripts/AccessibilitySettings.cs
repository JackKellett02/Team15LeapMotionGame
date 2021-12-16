////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:       AccessibilitySettings.cs
/// Author:         Chris Johnson
/// Date Created:   24/11/2021
/// Brief:  Functions relating to the accessibility settings page
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// functions relating to the accessability settings
/// </summary>
public class AccessibilitySettings : MonoBehaviour
{
    [SerializeField]
    Dropdown ColourBlindModeSlider;

    Effects effectsScript;

    private Material material;
    private Effects.ColorBlindMode mode = Effects.ColorBlindMode.Normal;
    private Effects.ColorBlindMode previousMode = Effects.ColorBlindMode.Normal;

    

    /// <summary>
    /// get referances and set colourblind material
    /// </summary>
    void Awake()
    {
        effectsScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Effects>();
        material = new Material(Shader.Find("Hidden/ChannelMixer"));
        material.SetColor("_R", effectsScript.RGB[0, 0]);
        material.SetColor("_G", effectsScript.RGB[0, 1]);
        material.SetColor("_B", effectsScript.RGB[0, 2]);
    }


    // Start is called before the first frame update
    void Start()
    {
        ColourBlindModeSlider.onValueChanged.AddListener(delegate { ColourBlindModeValueChanged(ColourBlindModeSlider); });
    }

    /// <summary>
    /// set the colourblind mode when selected from the list
    /// </summary>
    void ColourBlindModeValueChanged(Dropdown a_dropdown)
    {
        if (a_dropdown.value == 0)
        {
            mode = Effects.ColorBlindMode.Normal;
        }
        else if (a_dropdown.value == 1)
        {
            mode = Effects.ColorBlindMode.Protanopia;
        }
        else if (a_dropdown.value == 2)
        {
            mode = Effects.ColorBlindMode.Protanomaly;
        }
        else if (a_dropdown.value == 3)
        {
            mode = Effects.ColorBlindMode.Deuteranopia;
        }
        else if (a_dropdown.value == 4)
        {
            mode = Effects.ColorBlindMode.Deuteranomaly;
        }
        else if (a_dropdown.value == 5)
        {
            mode = Effects.ColorBlindMode.Tritanopia;
        }
        else if (a_dropdown.value == 6)
        {
            mode = Effects.ColorBlindMode.Tritanomaly;
        }
        else if (a_dropdown.value == 7)
        {
            mode = Effects.ColorBlindMode.Achromatopsia;
        }
        else if (a_dropdown.value == 8)
        {
            mode = Effects.ColorBlindMode.Achromatomaly;
        }
    }


    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        // No effect
        if (mode == Effects.ColorBlindMode.Normal)
        {
            Graphics.Blit(source, destination);
            return;
        }

        // Change effect
        if (mode != previousMode)
        {
            material.SetColor("_R", effectsScript.RGB[(int)mode, 0]);
            material.SetColor("_G", effectsScript.RGB[(int)mode, 1]);
            material.SetColor("_B", effectsScript.RGB[(int)mode, 2]);
            previousMode = mode;
        }

        // Apply effect
        Graphics.Blit(source, destination, material);
    }

}
