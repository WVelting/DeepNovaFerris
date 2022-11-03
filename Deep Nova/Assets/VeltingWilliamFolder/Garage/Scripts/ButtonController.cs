using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public string statName; //attribute for stat name
    public string unlocks; //attribute for what upgrade unlocks
    public string unlocks2; //attribute for second unlock
    public int statVal; //attribute for the total val upgrade will add to stat
    public int unlockInt; //attribute for how much the upgrade will add to unlock requirements
    public int upgradeCost; //attribute for how much is needed to unlock upgrade
    public string requirementName; //attribute for what is needed to unlock upgrade
    public int requirement; //current unlock stat
    public int numOfReqs; //how many requirements are needed to unlock
    public Button button; //the upgrade button

    public TextMeshProUGUI statText; //displays upgrade name
    public TextMeshProUGUI valText; //displays current stat val
    public TextMeshProUGUI upgradeText; //displays upgraded stat val
    public TextMeshProUGUI unlockText; //displays what will be unlocked
    public TextMeshProUGUI costText; //displays cost of upgrade
    public GameObject dialoguePanel; //panel that holds the upgrade information

    void Start()
    {
        // dialoguePanel.SetActive(false);
    }

    void Update()
    {

        if(PlayerPrefs.HasKey(requirementName)) requirement = PlayerPrefs.GetInt(requirementName);
        
        //makes sure that you can only upgrade if you have enough currency
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

        //disables buttons that are not unlocked yet
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

    //caches information stored in upgrade button to be used in the dialogue panel
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

    //changes stat values in Player Pref once the upgrade button from the dialogue box has been pressed
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

    //settles any unlocks that the upgrade has unlocked when the upgrade button from the dialogue box has been pressed
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

    //changes ships when a ship unlock button has been pressed
    public void OnShipUnlock()
    {
        PlayerPrefs.SetString("current-ship", statName);
        print(PlayerPrefs.GetString("current-ship"));
    }
}
