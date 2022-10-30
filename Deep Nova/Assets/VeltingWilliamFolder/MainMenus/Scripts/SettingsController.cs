using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public TMP_Text gameVal;
    public TMP_Text sfxVal;
    public Slider gameSlider;
    public Slider sfxSlider;

    public AudioSource gameAudio;
    public AudioSource sfxAudio;

    void Start()
    {
        gameSlider.value = PlayerPrefs.GetFloat("game-volume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfx-volume");

        OnVolValChanged();
    }
    
    void Update()
    {
        gameAudio.volume = gameSlider.value/100f;
        sfxAudio.volume = sfxSlider.value/100f;
        
    }

    public void OnVolValChanged()
    {
        gameVal.text = gameSlider.value.ToString();
        sfxVal.text = sfxSlider.value.ToString();
        PlayerPrefs.SetFloat("game-volume", gameSlider.value);
        PlayerPrefs.SetFloat("sfx-volume", sfxSlider.value);
    }

}
