using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolume2 : MonoBehaviour {

    // Reference to Audio Source component
    public AudioSource audioSrc;

    // Music volume variable that will be modified
    // by dragging slider knob
    private float musicVolume = 1f;

    // Use this for initialization
    void OnSceneLoaded()
    {

        // Assign Audio Source component to control it
       // audioSrc = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            musicVolume = PlayerPrefs.GetFloat("MasterVolume");
            GetComponent<Slider>().value = musicVolume;
        }
        else
        {
            PlayerPrefs.SetFloat("MasterVolume", 1f);
            PlayerPrefs.Save();
        }
    }

    // Update is called once per frame
    void Update()
    {

        // Setting volume option of Audio Source to be equal to musicVolume
        musicVolume = GetComponent<Slider>().value;
        if (musicVolume != audioSrc.volume)
        {
            audioSrc.volume = musicVolume;
            PlayerPrefs.SetFloat("MasterVolume", musicVolume);
            PlayerPrefs.Save();
        }
        
    }

    // Method that is called by slider game object
    // This method takes vol value passed by slider
    // and sets it as musicValue
    public void SetVolume(float vol)
    {
        
        musicVolume = vol;
    }
}
