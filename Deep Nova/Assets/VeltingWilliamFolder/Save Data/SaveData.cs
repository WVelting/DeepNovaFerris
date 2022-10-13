using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SaveData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerStat(string stat, int val)
    {
        PlayerPrefs.SetFloat(stat, val);
    }

    public void GetPlayerStat(string stat, int val)
    {
        PlayerPrefs.GetFloat(stat, val);
    }
}
