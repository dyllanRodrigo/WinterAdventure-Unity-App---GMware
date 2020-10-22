using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;


public class UniversalAudioManager : MonoBehaviour {

    public AudioMixer musicMixer;
    public AudioMixer fxMixer;

    public Slider volumeSlider;
    public Slider fxSlider;

    void Start() {
        volumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        fxSlider.value = PlayerPrefs.GetFloat("FxVolume");

    }


        void Update() {

        musicMixer.SetFloat("MusicVolume", volumeSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", volumeSlider.value);



        fxMixer.SetFloat("FxVolume", fxSlider.value);
        PlayerPrefs.SetFloat("FxVolume", fxSlider.value);
    }
}
