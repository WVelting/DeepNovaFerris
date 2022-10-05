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

    void Start()
    {
        gameSlider.value = 100;
        sfxSlider.value = 100;
        OnVolValChanged();
    }
    
    void Update()
    {
        
    }

    public void OnVolValChanged()
    {
        gameVal.text = gameSlider.value.ToString();
        sfxVal.text = sfxSlider.value.ToString();
    }

}
