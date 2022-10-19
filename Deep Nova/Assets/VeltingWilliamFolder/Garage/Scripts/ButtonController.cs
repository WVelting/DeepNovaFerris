using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public string statName;
    public string unlocks;
    public string unlocks2;
    public int statVal;
    public int unlockInt;
    public string requirementName;
    public int requirement;
    public int numOfReqs;
    public Button button;

    void Start()
    {
        
    }

    void Update()
    {
        if(PlayerPrefs.HasKey(requirementName)) requirement = PlayerPrefs.GetInt(requirementName);
        

        if(requirement < numOfReqs) 
        {
            button.image.color = new Vector4(0.4f,0.4f,0.4f,1);
            button.enabled = false;
            
        }
        else if(requirement == numOfReqs)
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
        if(statName!="")
        {
            print("pressed");
            string stat = statName;
            int val = PlayerPrefs.GetInt(stat) + statVal;
            PlayerPrefs.SetInt(stat, val); 
            print(PlayerPrefs.GetInt(stat));
        }
            requirement++;
            PlayerPrefs.SetInt(requirementName, requirement);
    }

    public void OnUnlockButtonPress()
    {
        print("pressed");
        int currentUnlock = PlayerPrefs.GetInt(unlocks);
        int unlockAmount = currentUnlock + unlockInt;
        PlayerPrefs.SetInt(unlocks, unlockAmount);
        print(unlocks + " is unlocked");
        if(unlocks2!="") 
        {
            PlayerPrefs.SetInt(unlocks2, unlockInt);
            print(unlocks2 + " is unlocked");
        }
        else return;
    }


    public void OnShipUnlock()
    {
        PlayerPrefs.SetString("current-ship", statName);
        print(PlayerPrefs.GetString("current-ship"));
    }
}
