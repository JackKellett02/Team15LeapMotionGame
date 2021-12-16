////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:       AudioSettings.cs
/// Author:         Chris Johnson
/// Date Created:   24/11/2021
/// Brief:  Functions relating to the audio settings page
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField]
    Slider masterVolumeSlider;
    [SerializeField]
    Slider musicVolumeSlider;
    [SerializeField]
    Slider SFXVolumeSlider;

    [SerializeField]
    AudioMixer audioPlayers;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void UpdateMaster()
    {
	    audioPlayers.SetFloat("MasterVolume", masterVolumeSlider.value);
    }

    public void UpdateMusic()
    {
	    audioPlayers.SetFloat("MusicVolume", musicVolumeSlider.value);
    }

    public void UpdateSFX()
    {
	    audioPlayers.SetFloat("SFXVolume", SFXVolumeSlider.value);
    }
}
