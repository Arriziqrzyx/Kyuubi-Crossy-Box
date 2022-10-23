using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider masterVolume;
    [SerializeField] Slider BGM;
    [SerializeField] Slider SFX;
    public static AudioManager Instance { get; set; }
    private void Awake() {
        float db;
        if(audioMixer.GetFloat("MasterVol", out db))
            masterVolume.value = (db+80)/80;

        if(audioMixer.GetFloat("BGMVol", out db))
            BGM.value = (db+80)/80;

        if(audioMixer.GetFloat("SFXVol", out db))
            SFX.value = (db+80)/80;
    }

    public void SetMasterVolume(float volume) {
        volume = volume * 80 - 80;
        audioMixer.SetFloat("MasterVol", volume);
        PlayerPrefs.SetFloat("MasterVol", volume);
        PlayerPrefs.Save();
    }

    public void SetBGMVolume(float volume) {
        volume = volume * 80 - 80;
        audioMixer.SetFloat("BGMVol", volume);
        PlayerPrefs.SetFloat("BGMVol", volume);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float volume) {
        volume = volume * 80 - 80;
        audioMixer.SetFloat("SFXVol", volume);
        PlayerPrefs.SetFloat("SFXVol", volume);
        PlayerPrefs.Save();
    }




}
