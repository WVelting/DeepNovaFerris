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

    public void OnReset()
    {
        PlayerPrefs.SetInt("ship-speed", 0);
        PlayerPrefs.SetInt("ship-damage", 0);
        PlayerPrefs.SetInt("ship-firerate", 0);
        PlayerPrefs.SetInt("ship-itemradius", 0);
        PlayerPrefs.SetInt("ship-health", 0);
        PlayerPrefs.SetInt("ship-speed2unlock", 0);
        PlayerPrefs.SetInt("ship-damage2unlock", 0);
        PlayerPrefs.SetInt("ship-firerate2unlock", 0);
        PlayerPrefs.SetInt("ship-itemradius2unlock", 0);
        PlayerPrefs.SetInt("ship-health2unlock", 0);
        PlayerPrefs.SetInt("plasmic", 0);
        PlayerPrefs.SetInt("lcpb", 0);
        PlayerPrefs.SetInt("gatling-laser", 0);
        PlayerPrefs.SetInt("entropic-gg", 0);
        PlayerPrefs.SetInt("ehdg", 0);
        PlayerPrefs.SetInt("plasma-throwers", 0);
        PlayerPrefs.SetInt("thermal-venting", 0);
        PlayerPrefs.SetInt("mass-fluct", 0);
        PlayerPrefs.SetInt("lcpb2", 0);
        PlayerPrefs.SetInt("plasma-throwers2", 0);
        PlayerPrefs.SetInt("thermal-venting2", 0);
        PlayerPrefs.SetInt("mass-fluct2", 0);
        PlayerPrefs.SetInt("ehdg2", 0);
        PlayerPrefs.SetInt("quetzal", 0);
        PlayerPrefs.SetInt("first-ship-speed", 1);
        PlayerPrefs.SetInt("first-ship-damage", 1);
        PlayerPrefs.SetInt("first-ship-firerate", 1);
        PlayerPrefs.SetInt("first-ship-itemradius", 1);
        PlayerPrefs.SetInt("first-ship-health", 1);
        PlayerPrefs.SetString("current-ship", "");
        print("first ship speed " + PlayerPrefs.GetInt("first-ship-speed"));
        print("ship speed " + PlayerPrefs.GetInt("ship-speed"));
        print("ship 2 speed unlocked " + PlayerPrefs.GetInt("ship-speed2unlock"));
        print("plasmic unlocked " + PlayerPrefs.GetInt("plasmic"));
    }
}
