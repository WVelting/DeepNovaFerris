using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    // state:
    public float health { get; private set; }
    public float healthMax = 100;

    private float cooldownInvulnerability = 0;

    public float shieldHealth { get; private set; }
    public float shieldHealthMax = 100;

    public float shieldTimer = 0f;
    public float shieldDuration = 10f;

    //behavior
    private void Start()
    {
        health = healthMax;
        shieldHealth = 0;
    }

    private void Update()
    {
        if (cooldownInvulnerability > 0) cooldownInvulnerability -= Time.deltaTime;
        ShieldTimer();
    }

    public void TakeDamage(float amt)
    {
        if(shieldHealth > 0) // shield is active, only shield will take damage
        {
            if (cooldownInvulnerability > 0) return; //damage cooldown not finished yet

            cooldownInvulnerability = 0.2f; // period of invulnerability after getting hit

            if (amt < 0) amt = 0; // negative damage amount is ignored
            shieldHealth -= amt; // shield takes damage by amt number
        }        
        
        if (shieldHealth <= 0) // shield isn't active, player health will be affected
        {
            if (cooldownInvulnerability > 0) return; // cooldown not finished

            cooldownInvulnerability = 0.5f; // cooldown until we can take damage again

            if (amt < 0) amt = 0; // negative numbers are ignored
            health -= amt; // health = health - amt
            if (health <= 0) Die(); // health is 0 or less, object is dead
        }
    }

    public void ShieldTimer()
    {
        if(shieldHealth > 0)
        {
            shieldTimer -= Time.deltaTime;
        }

        if(shieldTimer <= 0f)
        {
            shieldHealth = 0;
        }
    }

    public void Heal(float amt)
    {
        if (cooldownInvulnerability > 0) return; // cooldown not finished

        cooldownInvulnerability = 0.15f; // cooldown until we can take damage (or heal) again

        if (amt < 0) amt = 0;
        health += amt; // health = health + amt
        if (health >= 100) health = 100;
    }

    public void Die()
    {
        Destroy(gameObject); // placeholder death solution, could be replaced with gameover screen,
                             // or restart level if player still has lives
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Shield")
        {
            shieldHealth = shieldHealthMax;
            Destroy(other.gameObject);
            shieldTimer = shieldDuration;
        }
    }
}
