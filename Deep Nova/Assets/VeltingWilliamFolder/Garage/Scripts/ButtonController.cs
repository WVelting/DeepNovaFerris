using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public string statName;
    public string unlocks;
    public int statVal;
    public int unlockInt;
    public string requirementName;
    public int requirement;
    public Button button;

    void Start()
    {
        
    }

    void Update()
    {
        if(PlayerPrefs.HasKey(requirementName)) requirement = PlayerPrefs.GetInt(requirementName);
        

        if(requirement < 1) 
        {
            button.image.color = new Vector4(0.4f,0.4f,0.4f,1);
            button.enabled = false;
            
        }
        else if(requirement == 1)
        {
            button.image.color = new Vector4(1,1,1,1);
            button.enabled = true;

        }
        else{
            button.image.color = new Vector4(0,.7f,0,1);
            button.enabled = false;
        }
    }

    public void OnValButtonPress()
    {
        print("pressed");
        string stat = statName;
        int val = PlayerPrefs.GetInt(stat) + statVal;
       PlayerPrefs.SetInt(stat, val); 
       print(PlayerPrefs.GetInt(stat));
       requirement++;
       PlayerPrefs.SetInt(requirementName, requirement);
    }

    public void OnBoolButtonPress()
    {
        print("pressed");
        PlayerPrefs.SetInt(unlocks, unlockInt);
        print(unlocks + " is unlocked");
    }

    void OnDisabled()
    {
        button.image.color = new Vector4(116,166,166,255);
    }
}
