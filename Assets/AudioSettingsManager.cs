using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettingsManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Scrollbar[] scrollbars;
    [SerializeField]
    AudioMixer audioMixer;
    String[] volumeKeys = 
    {
        "Music Volume",
        "SFX Volume",
        "Master Volume"
    };

    public enum VolumeGroups
    {
        musicVolume,
        sfxVolume,
        masterVolume

    }
    void Start()
    {
        

        // Initalize and set volume variables 
        String musicVolumeKey = volumeKeys[ (int) VolumeGroups.musicVolume];
        String sfxVolumeKey = volumeKeys[ (int) VolumeGroups.sfxVolume];
        String masterVolumeKey = volumeKeys[ (int) VolumeGroups.masterVolume];

        PlayerPrefs.SetFloat(musicVolumeKey, PlayerPrefs.GetFloat(musicVolumeKey,0.0f));
        PlayerPrefs.SetFloat(sfxVolumeKey, PlayerPrefs.GetFloat(sfxVolumeKey, 0.0f));
        PlayerPrefs.SetFloat(masterVolumeKey, PlayerPrefs.GetFloat(masterVolumeKey, 1.0f));
        // Add events for updating values
        //Debug.Log(group.ToString());
        scrollbars[0].onValueChanged.AddListener((float val) => updateVolume(val, (VolumeGroups) 0));
        scrollbars[1].onValueChanged.AddListener((float val) => updateVolume(val, (VolumeGroups) 1));
        scrollbars[0].onValueChanged.AddListener((float val) => updateVolume(val, (VolumeGroups) 0));
        
        
       
        //updateVolume(PlayerPrefs.GetFloat(sfxVolumeKey, 0.0f), VolumeGroups.sfxVolume);
        //updateVolume(PlayerPrefs.GetFloat(musicVolumeKey, 0.0f), VolumeGroups.musicVolume);
        //updateVolume(PlayerPrefs.GetFloat(masterVolumeKey, 0.0f), VolumeGroups.masterVolume);

    }


    public void updateVolume(int scrollbarIndex)
    {
        float volume = scrollbars[scrollbarIndex].value;
        updateVolume(volume, (VolumeGroups) scrollbarIndex);
    }
    
    public void updateVolume(float volumeInput, VolumeGroups group)
    {
        float trueVol = volumeInput * -40.0f;
        if(trueVol < -35.0f)
            trueVol = -80.0f;
        Debug.Log("Group " + group.ToString() + "(" + (int) group + ")");
        String key = volumeKeys[(int) group];
        PlayerPrefs.SetFloat(key, trueVol);
        audioMixer.SetFloat(key, PlayerPrefs.GetFloat(key));
        Debug.Log("Setting group " + group + " to: " + trueVol);
    }

}
