using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyButtonController : MonoBehaviour
{
    public TextMeshProUGUI moneyCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyCount.SetText("Money<br>" + PlayerPrefs.GetInt("player-currency"));
    }

    public void AddMoney()
    {
        int currentMoney = PlayerPrefs.GetInt("player-currency");
        int moreMoney = currentMoney + 5000;
        PlayerPrefs.SetInt("player-currency", moreMoney);
    }
}
