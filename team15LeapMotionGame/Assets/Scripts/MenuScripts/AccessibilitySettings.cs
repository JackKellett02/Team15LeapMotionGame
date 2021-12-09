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

public class AccessibilitySettings : MonoBehaviour
{
    [SerializeField]
    Dropdown ColourBlindModeSlider;

    // Start is called before the first frame update
    void Start()
    {
        ColourBlindModeSlider.onValueChanged.AddListener(delegate { ColourBlindModeValueChanged(ColourBlindModeSlider); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ColourBlindModeValueChanged(Dropdown dropdown)
    {

    }

}
