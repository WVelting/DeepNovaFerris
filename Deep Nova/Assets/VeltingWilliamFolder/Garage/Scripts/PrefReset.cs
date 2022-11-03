using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //resets all of the main Player Pref values
    public void OnReset()
    {
        //Main Prefs
        PlayerPrefs.SetInt("Ship Speed", 0);
        PlayerPrefs.SetInt("Damage", 0);
        PlayerPrefs.SetInt("Fire Rate", 0);
        PlayerPrefs.SetInt("Item Pickup Radius", 0);
        PlayerPrefs.SetInt("Shield Health", 0);
        PlayerPrefs.SetInt("ship-speed2unlock", 0);
        PlayerPrefs.SetInt("ship-damage2unlock", 0);
        PlayerPrefs.SetInt("ship-firerate2unlock", 0);
        PlayerPrefs.SetInt("ship-itemradius2unlock", 0);
        PlayerPrefs.SetInt("ship-health2unlock", 0);
        PlayerPrefs.SetInt("Plasmic Engineering", 0);
        PlayerPrefs.SetInt("lcpb", 0);
        PlayerPrefs.SetInt("Gatling Laser", 0);
        PlayerPrefs.SetInt("Entropic Gravity Generator", 0);
        PlayerPrefs.SetInt("ehdg", 0);
        PlayerPrefs.SetInt("plasma-throwers", 0);
        PlayerPrefs.SetInt("thermal-venting", 0);
        PlayerPrefs.SetInt("mass-fluct", 0);
        PlayerPrefs.SetInt("lcpb2", 0);
        PlayerPrefs.SetInt("plasma-throwers2", 0);
        PlayerPrefs.SetInt("thermal-venting2", 0);
        PlayerPrefs.SetInt("mass-fluct2", 0);
        PlayerPrefs.SetInt("ehdg2", 0);
        PlayerPrefs.SetInt("Quetzal Mk V", 0);
        PlayerPrefs.SetInt("first-ship-speed", 1);
        PlayerPrefs.SetInt("first-ship-damage", 1);
        PlayerPrefs.SetInt("first-ship-firerate", 1);
        PlayerPrefs.SetInt("first-ship-itemradius", 1);
        PlayerPrefs.SetInt("first-ship-health", 1);
        PlayerPrefs.SetString("current-ship", "");
        PlayerPrefs.SetInt("player-currency", 0);
        print("first ship speed " + PlayerPrefs.GetInt("first-ship-speed"));
        print("ship speed " + PlayerPrefs.GetInt("ship-speed"));
        print("ship 2 speed unlocked " + PlayerPrefs.GetInt("ship-speed2unlock"));
        print("plasmic unlocked " + PlayerPrefs.GetInt("plasmic"));

    }

    //resets the cached Player Pref values
    public void CacheReset()
    {
        //cached Prefs
        PlayerPrefs.SetInt("resetter", 0);
        PlayerPrefs.SetString("temp-stat-name", "");
        PlayerPrefs.SetInt("temp-stat-val", 0);
        PlayerPrefs.SetString("temp-unlocks", "");
        PlayerPrefs.SetString("temp-unlocks2", "");
        PlayerPrefs.SetInt("temp-unlock-val", 0);
        PlayerPrefs.SetString("temp-requirement", "");
        PlayerPrefs.SetInt("temp-requirement-amount", 0);

    }
}
