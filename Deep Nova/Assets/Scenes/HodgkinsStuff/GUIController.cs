using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    public Text playerHealthDisplay;
    public HealthSystem playerHealth;

    public Text shieldHealthDisplay;
    public HealthSystem shieldHealth;

    public Text shieldEnergyDisplay;
    public HealthSystem shieldEnergy;

    public Text dmfDisplay;
    public ShipMovement DMF;
    
    void Start()
    {
        
    }


    void Update()
    {
        playerHealthDisplay.text = playerHealth.health + " ";

        if (playerHealth.health < 0) playerHealthDisplay.text = "0";


        shieldEnergyDisplay.text = "Energy: " + (Mathf.FloorToInt((shieldEnergy.shieldTimer) * 10) + "%");

        if (shieldEnergy.shieldTimer <= 0) shieldEnergyDisplay.text = " ";


        shieldHealthDisplay.text = "Shield Health: " + shieldHealth.shieldHealth;

        if (shieldHealth.shieldHealth <= 0) shieldHealthDisplay.text = "Shield Disabled";


        dmfDisplay.text = "Dark Matter Fuel: " + (Mathf.FloorToInt((DMF.dmfTime) * 28.6f) + "%");

        if (DMF.dmfTime <= 0) dmfDisplay.text = " ";

    }
}
