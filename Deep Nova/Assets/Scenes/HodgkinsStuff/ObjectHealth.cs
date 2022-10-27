using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    // state:
    public float health { get; private set; }
    public float healthMax = 40;

    //variable for how long something is invulnerable after getting hit
    private float cooldownInvulnerability = 0;

    private void Start()
    {
        //health starts as the max set
        health = healthMax;
    }

    private void Update()
    {
        //if recently hit, start invylnerability cooldown
        if (cooldownInvulnerability > 0) cooldownInvulnerability -= Time.deltaTime;
    }

    public void TakeDamage(float amt)
    {       
        if (cooldownInvulnerability > 0) return; // invuln cooldown not finished

        cooldownInvulnerability = 0.05f; // cooldown until we can take damage again

        if (amt < 0) amt = 0; // negative numbers are ignored
        health -= amt; // health = health - amt
        if (health <= 0) Die(); // health is 0 or less, object is dead
    }
    
    public void Die()
    {
        Destroy(gameObject); // placeholder death solution
    }

}
