using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    //text of game volume slider
    public TMP_Text gameVal;
    //text of sfx volume slider
    public TMP_Text sfxVal;
    //game volume slider
    public Slider gameSlider;
    //sfx volume slider
    public Slider sfxSlider;

    //tester audio for game volume
    public AudioSource gameAudio;
    //tester audio for sfx volume
    public AudioSource sfxAudio;

    void Start()
    {
        //sets volume sliders to values stored in Player Prefs
        gameSlider.value = PlayerPrefs.GetFloat("game-volume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfx-volume");

        OnVolValChanged();
    }
    
    void Update()
    {
        //Updates the game audio to correlate to slider values
        gameAudio.volume = gameSlider.value/100f;
        sfxAudio.volume = sfxSlider.value/100f;
        
    }

    //changes text and value in Player Prefs when the slider is adjusted
    public void OnVolValChanged()
    {
        gameVal.text = gameSlider.value.ToString();
        sfxVal.text = sfxSlider.value.ToString();
        PlayerPrefs.SetFloat("game-volume", gameSlider.value);
        PlayerPrefs.SetFloat("sfx-volume", sfxSlider.value);
    }

}
