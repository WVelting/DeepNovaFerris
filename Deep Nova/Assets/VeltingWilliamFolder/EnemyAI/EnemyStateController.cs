using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateController : MonoBehaviour
{

    private EnemyShip enemy;
    private GameObject player;
    void Start()
    {
        enemy = GetComponent<EnemyShip>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        SteerToPlayer();
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

    void SteerToPlayer()
    {
        Vector3 vToP = player.transform.position - enemy.transform.position;
        Quaternion dirToP = Quaternion.LookRotation(vToP, Vector3.up);
        float visionDistance = 500;
        float speed = 3;

        enemy.transform.rotation = dirToP;

        if(vToP.sqrMagnitude < visionDistance * visionDistance)
        {
            enemy.transform.position = Lerp(transform.position, player.transform.position, .005f);
        }
    }

}
