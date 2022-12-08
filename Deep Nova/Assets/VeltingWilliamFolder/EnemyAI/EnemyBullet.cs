using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    private GameObject player;
    private Vector3 playerPos;
    private float lifeTimer = 10;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Lerp(transform.position, playerPos, .75f);
        if((transform.position - player.transform.position).magnitude <= 100)
        {
            PlayerPrefs.SetInt("player-health", PlayerPrefs.GetInt("player-health") - 25);
            Destroy(this);
        }

        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0) Destroy(this);
    }

    public static Vector3 Lerp(Vector3 a, Vector3 b, float p)
    {
        Vector3 result = new Vector3();

        result.x = Lerp(a.x, b.x, p);
        result.y = Lerp(a.y, b.y, p);
        result.z = Lerp(a.z, b.z, p);

        return result;
    }

    public static float Lerp(float a, float b, float p)
    {
        return (b - a) * p + a;
    }
}
