using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    public Text playerHealthDisplay;
    public HealthSystem playerHealth;
    
    
    void Start()
    {
        
    }


    void Update()
    {
        playerHealthDisplay.text = playerHealth.health + " ";

        if (playerHealth.health < 0) playerHealthDisplay.text = "0";
    }
}
