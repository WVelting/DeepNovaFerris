using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupFly : MonoBehaviour
{
    public GameObject player;

    private Vector3 playerPos;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;

        transform.position = Vector3.MoveTowards(transform.position, playerPos, 2.5f);

    }
}
