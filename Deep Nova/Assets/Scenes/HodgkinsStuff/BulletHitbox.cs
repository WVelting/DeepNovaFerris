using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitbox : MonoBehaviour
{
    public float bulletDamage = 20;


    public void OnTriggerEnter(Collider other)
    {
        ObjectHealth health = other.GetComponent<ObjectHealth>();

        if (health)
        {
            health.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }

    }
}
