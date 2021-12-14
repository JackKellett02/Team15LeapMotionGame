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

    GameObject[] audioPlayers;
    GameObject[] musicPlayers;

    // Start is called before the first frame update
    void Start()
    {
        masterVolumeSlider.onValueChanged.AddListener(delegate { masterValueChanged(masterVolumeSlider); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { musicValueChanged(musicVolumeSlider); });
        SFXVolumeSlider.onValueChanged.AddListener(delegate { SFXValueChanged(SFXVolumeSlider); });

        audioPlayers = GameObject.FindGameObjectsWithTag("Audio");
        musicPlayers = GameObject.FindGameObjectsWithTag("Music");


    }

    /// <summary>
    /// update all audio players
    /// </summary>
    /// <param name="a_slider"></param>
    void masterValueChanged(Slider a_slider)
    {
        UpdateMusic();
        UpdateSFX();
    }

    /// <summary>
    /// set all music players to the updated volume
    /// </summary>
    /// <param name="a_slider"></param>
    void musicValueChanged(Slider a_slider)
    {
        UpdateMusic();
    }

    /// <summary>
    /// set all sfx players to the updated volume
    /// </summary>
    /// <param name="a_slider"></param>
    void SFXValueChanged(Slider a_slider)
    {
        UpdateSFX();
    }


    public void UpdateSFX()
    {
        foreach (GameObject go in audioPlayers)
        {
            go.GetComponent<AudioSource>().volume = (musicVolumeSlider.value / masterVolumeSlider.value);
        }
    }
    public void UpdateMusic()
    {
        foreach (GameObject go in musicPlayers)
        {
            go.GetComponent<AudioSource>().volume = (musicVolumeSlider.value / masterVolumeSlider.value);
        }
    }
}
