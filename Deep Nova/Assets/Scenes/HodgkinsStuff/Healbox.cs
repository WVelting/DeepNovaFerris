using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healbox : MonoBehaviour
{
    public float healAmount = 10;

    public void OnTriggerEnter(Collider other)
    {
        HealthSystem health = other.GetComponent<HealthSystem>();

        if (health)
        {
            health.Heal(healAmount);
            Destroy(gameObject);
        }

    }
}
