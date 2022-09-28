using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public float damageAmount = 20;


    public void OnTriggerEnter(Collider other)
    {
        HealthSystem health = other.GetComponent<HealthSystem>();

        if (health)
        {
            health.TakeDamage(damageAmount);
            Destroy(gameObject);
        }



    }
}
