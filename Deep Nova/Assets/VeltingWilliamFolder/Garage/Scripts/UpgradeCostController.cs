using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCostController : MonoBehaviour
{
    public Button upgradeButton;

    void Start()
    {
        
    }

    void Update()
    {
        if(PlayerPrefs.GetInt("player-currency") < PlayerPrefs.GetInt("temp-upgrade-cost"))
        {
            upgradeButton.image.color = new Vector4(.4f,.4f,.4f, 1);
            upgradeButton.enabled = false;
            print("can't buy");
        }

        else
        {
            upgradeButton.image.color = new Vector4(1, 1, 1, 1);
            upgradeButton.enabled = true;
            print("can buy");
        }
    }
}
