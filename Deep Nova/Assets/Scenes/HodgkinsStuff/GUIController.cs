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

    public Text paDisplay;
    public Tom_PlayerGun protoAmmo;
    
    void Start()
    {
        
    }


    void Update()
    {
        playerHealthDisplay.text = playerHealth.health + " ";

        if (playerHealth.health < 0) playerHealthDisplay.text = "0";


        shieldEnergyDisplay.text = "Energy: " + (Mathf.FloorToInt((shieldEnergy.shieldTimer) * 10) + "%");

        if (shieldEnergy.shieldTimer <= 0 || shieldHealth.shieldHealth <= 0) shieldEnergyDisplay.text = " ";


        shieldHealthDisplay.text = "Shield Health: " + shieldHealth.shieldHealth;

        if (shieldHealth.shieldHealth <= 0) shieldHealthDisplay.text = "Shield Disabled";


        dmfDisplay.text = "Dark Matter Fuel: " + (Mathf.FloorToInt((DMF.dmfTime) * 28.6f) + "%");

        if (DMF.dmfTime <= 0) dmfDisplay.text = " ";


        paDisplay.text = "Prototype Ammo Timer: " + (Mathf.FloorToInt(protoAmmo.protoAmmoTimer) + 1);

        if (protoAmmo.protoAmmoTimer <= 0) paDisplay.text = " ";

    }
}
