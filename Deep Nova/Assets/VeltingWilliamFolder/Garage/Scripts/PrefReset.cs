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
        PlayerPrefs.SetInt("first-ship-speed", 1);
        PlayerPrefs.SetInt("first-ship-damage", 1);
        PlayerPrefs.SetInt("first-ship-firerate", 1);
        PlayerPrefs.SetInt("first-ship-itemradius", 1);
        PlayerPrefs.SetInt("first-ship-health", 1);
        print("first ship speed " + PlayerPrefs.GetInt("first-ship-speed"));
        print("ship speed " + PlayerPrefs.GetInt("ship-speed"));
        print("ship 2 speed unlocked " + PlayerPrefs.GetInt("ship-speed2unlock"));
        print("plasmic unlocked " + PlayerPrefs.GetInt("plasmic"));
    }
}
