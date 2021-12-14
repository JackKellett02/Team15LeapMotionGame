////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:       AccessibilitySettings.cs
/// Author:         Chris Johnson
/// Date Created:   05/12/2021
/// Brief:  colour blind mode shader effects
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// colour blind mode shader effect values 
/// </summary>
public class Effects : MonoBehaviour
{
	private void Start()
	{
        DontDestroyOnLoad(this.gameObject);
	}

    //each colourblind mode possible
    public enum ColorBlindMode
    {
        Normal = 0,
        Protanopia = 1,
        Protanomaly = 2,
        Deuteranopia = 3,
        Deuteranomaly = 4,
        Tritanopia = 5,
        Tritanomaly = 6,
        Achromatopsia = 7,
        Achromatomaly = 8,
    }

    // rgb values for each colour blind mode
    public Color[,] RGB = new Color[9,3] { 
        { new Color(1,0,0), new Color(0,1,0), new Color(0,0,1) }, //normal
        { new Color(0.567f,0.433f,0), new Color(0.558f,0.442f,0), new Color(0,0.242f,0.758f) }, //Protanopia
        { new Color(0.816f,0.184f,0), new Color(0.334f,0.666f,0), new Color(0,0.125f,0.875f) }, //Protanomaly
        { new Color(0.625f,0.375f,0), new Color(0,0.7f,0.3f), new Color(0,0.3f,0.7f) }, //Deuteranopia
        { new Color(0,0.8f,0.2f), new Color(0,0.258f,0.742f), new Color(0,0.142f,0.858f) }, //Deuteranomaly
        { new Color(0,0.95f,0.05f), new Color(0,0.433f,0.567f), new Color(0,0.475f,0.525f) }, //Tritanopia
        { new Color(0.966f,0.334f,0), new Color(0, 0.733f,0.267f), new Color(0,0.183f,0.817f) }, //Tritanomaly
        { new Color(0.299f,0.587f,0.114f), new Color(0.299f,0.587f,0.114f), new Color(0.299f,0.587f,0.114f) }, //Achromatopsia
        { new Color(0.618f,0.32f,0.62f), new Color(0.163f,0.775f,0.062f), new Color(0.163f,0.320f,0.517f) } //Achromatomaly
    };

}
