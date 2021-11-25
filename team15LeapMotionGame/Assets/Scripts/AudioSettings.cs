////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:       AudioSettings.cs
/// Author:         Chris Johnson
/// Date Created:   24/11/2021
/// Brief:  Functions relating to the audio settings page
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField]
    Slider masterVolumeSlider;
    [SerializeField]
    Slider musicVolumeSlider;
    [SerializeField]
    Slider SFXVolumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        masterVolumeSlider.onValueChanged.AddListener(delegate { masterValueChanged(masterVolumeSlider); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { musicValueChanged(musicVolumeSlider); });
        SFXVolumeSlider.onValueChanged.AddListener(delegate { SFXValueChanged(SFXVolumeSlider); });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a_slider"></param>
    void masterValueChanged(Slider a_slider)
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a_slider"></param>
    void musicValueChanged(Slider a_slider)
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a_slider"></param>
    void SFXValueChanged(Slider a_slider)
    {

    }
}
