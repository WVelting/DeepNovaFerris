using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupContainer : MonoBehaviour
{
    public bool isBroken;

    //public GameObject Nanobot;
    //public GameObject Shield;
    //public GameObject darkMatter;

    public GameObject[] powerups = new GameObject[4];

    private Vector3 powerupLocation;

    // Start is called before the first frame update
    void Start()
    {
        isBroken = false;
        powerupLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isBroken)
        {
            int numPU = Random.Range(0, powerups.Length);

            GameObject powerup = powerups[numPU];


            GameObject pu = Instantiate(powerup, powerupLocation, Quaternion.identity);
            
            Destroy(gameObject);

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            isBroken = true;
        }
    }
}
