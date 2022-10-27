using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public string statName;
    public string unlocks;
    public string unlocks2;
    public int statVal;
    public int unlockInt;
    public int upgradeCost;
    public string requirementName;
    public int requirement;
    public int numOfReqs;
    public Button button;

    public TextMeshProUGUI statText;
    public TextMeshProUGUI valText;
    public TextMeshProUGUI upgradeText;
    public TextMeshProUGUI unlockText;
    public TextMeshProUGUI costText;
    public GameObject dialoguePanel;

    void Start()
    {
        // dialoguePanel.SetActive(false);
    }

    void Update()
    {
        if(PlayerPrefs.HasKey(requirementName)) requirement = PlayerPrefs.GetInt(requirementName);
        
        if(requirementName == "resetter")
        {
            if(PlayerPrefs.GetInt("player-currency") < PlayerPrefs.GetInt("temp-upgrade-cost"))
            {
                button.image.color = new Vector4(0.4f,0.4f,0.4f,1);
                button.enabled = false;
            }
            else
            {
                button.image.color = new Vector4(1, 1, 1, 1);
                button.enabled = true;
            }
        }

        else
        {

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
    }

    public void OnUpgradeButtonPress()
    {
        PlayerPrefs.SetString("temp-stat-name", statName);
        PlayerPrefs.SetInt("temp-stat-val", statVal);
        PlayerPrefs.SetString("temp-unlocks", unlocks);
        PlayerPrefs.SetString("temp-unlocks2", unlocks2);
        PlayerPrefs.SetInt("temp-unlock-val", unlockInt);
        PlayerPrefs.SetString("temp-requirement", requirementName);
        PlayerPrefs.SetInt("temp-requirement-amount", requirement);
        PlayerPrefs.SetInt("temp-upgrade-cost", upgradeCost);

        print("cost for upgrade is " + PlayerPrefs.GetInt("temp-upgrade-cost"));
        print("player money is " + PlayerPrefs.GetInt("player-currency"));

        if(PlayerPrefs.GetString("temp-stat-name") != "")
        {
            statText.SetText(statName);
            valText.SetText("Current Value<br>" + PlayerPrefs.GetInt(statName).ToString());
            upgradeText.SetText("Upgraded Value<br>" + (PlayerPrefs.GetInt(statName)+statVal).ToString());
            costText.SetText("Upgrade Cost<br>" + PlayerPrefs.GetInt("temp-upgrade-cost").ToString());
            unlockText.SetText("");
            dialoguePanel.SetActive(true);
            print("dialogue panel open");

        }

        else
        {
            statText.SetText("");
            valText.SetText("");
            upgradeText.SetText("");
            costText.SetText("Upgrade Cost<br>" + PlayerPrefs.GetInt("temp-upgrade-cost").ToString());
            unlockText.SetText(PlayerPrefs.GetString("temp-requirement") + " will be unlocked by purchasing.");
            dialoguePanel.SetActive(true);
        }

    }

    public void OnValButtonPress()
    {
        if(PlayerPrefs.GetString("temp-stat-name")!="")
        {
            print("pressed");
            string stat = PlayerPrefs.GetString("temp-stat-name");
            int val = PlayerPrefs.GetInt(stat) + PlayerPrefs.GetInt("temp-stat-val");
            PlayerPrefs.SetInt(stat, val); 
            print("stat is " + PlayerPrefs.GetInt(stat));
        }
        
        int newRequirement = PlayerPrefs.GetInt(PlayerPrefs.GetString("temp-requirement"));
        
        newRequirement ++;
        
        PlayerPrefs.SetInt(PlayerPrefs.GetString("temp-requirement"), newRequirement);
        int currentMoney = PlayerPrefs.GetInt("player-currency");
        int newMoney = currentMoney - PlayerPrefs.GetInt("temp-upgrade-cost");
        PlayerPrefs.SetInt("player-currency", newMoney);
        dialoguePanel.SetActive(false);

    }

    public void OnUnlockButtonPress()
    {
        print("pressed");
        int currentUnlock = PlayerPrefs.GetInt(PlayerPrefs.GetString("temp-unlocks"));
        int unlockAmount = currentUnlock + PlayerPrefs.GetInt("temp-unlock-val");
        PlayerPrefs.SetInt(PlayerPrefs.GetString("temp-unlocks"), unlockAmount);
        print(PlayerPrefs.GetString("temp-unlocks") + " is unlocked");

        if(PlayerPrefs.GetString("temp-unlocks2")!="")
        {
            PlayerPrefs.SetInt(PlayerPrefs.GetString("temp-unlocks2"), unlockAmount);
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
