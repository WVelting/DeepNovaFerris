using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateController : MonoBehaviour
{

    private EnemyShip enemy; //enemy ship
    private GameObject player; //player ship

    public GameObject projectile;

    public Vector3 randomPath;
    public Vector3 originPosition;
    public float attackTimer = 0.5f;
    void Start()
    {
        enemy = GetComponent<EnemyShip>(); //assigns enemy ship to enemy
        player = GameObject.FindGameObjectWithTag("Player"); //assigns player ship to player
        originPosition = transform.position;
        CalcNewPath();

    }

    // Update is called once per frame
    void Update()
    {
        SteerToPlayer();

        if((player.transform.position - transform.position).magnitude <= 5000) Attack();

        attackTimer -= Time.deltaTime;
        
        //Wander();
    }

    //lerp function for animation purposes
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

    public static Quaternion Lerp(Quaternion a, Quaternion b, float p)
    {
        b = WrapQuaternion(a, b);
        
        Quaternion rot = Quaternion.identity;

        rot.x = Lerp(a.x, b.x, p);
        rot.y = Lerp(a.y, b.y, p);
        rot.z = Lerp(a.z, b.z, p);
        rot.w = Lerp(a.w, b.w, p);

        return rot;
    }

    public static float AngleWrapDegrees(float baseAngle, float angleToBeWrapped)
    {
        while (baseAngle > angleToBeWrapped + 180) angleToBeWrapped += 360;
        while(baseAngle < angleToBeWrapped - 180) angleToBeWrapped -= 360;

        return angleToBeWrapped;

    }

    public static Quaternion WrapQuaternion(Quaternion baseAngle, Quaternion angleToBeWrapped)
    {
        float alignment = Quaternion.Dot(baseAngle, angleToBeWrapped);

        if(alignment < 0)
        {
            angleToBeWrapped.x *= -1;
            angleToBeWrapped.y *= -1;
            angleToBeWrapped.z *= -1;
            angleToBeWrapped.w *= -1;

        }

        return angleToBeWrapped;
    }

    //has enemy ship look toward player and then move toward player once a set distance has been reached between the two players
    void SteerToPlayer()
    {
        Vector3 vToP = player.transform.position - enemy.transform.position;
        Quaternion dirToP = Quaternion.LookRotation(vToP, Vector3.up);
        float visionDistance = 500;
        float speed = 3;

        enemy.transform.rotation = dirToP;

        if(vToP.sqrMagnitude < visionDistance * visionDistance)
        {
            enemy.transform.position = Lerp(transform.position, player.transform.position + player.transform.forward*200 + player.transform.up*50, .008f);
        }
    }

    void Wander()
    {
        if((transform.position - randomPath).magnitude >= 50)
        {
            if((transform.position - originPosition).magnitude <= 150)
            {
                Quaternion lookForward = Quaternion.LookRotation((randomPath - transform.position), Vector3.up);
                transform.position = Lerp(transform.position, randomPath, .001f);
                transform.rotation = Lerp(transform.rotation, lookForward, .005f);
            }

            else randomPath = originPosition;
        }
        else
        {
            CalcNewPath();
        }
    }

    Vector3 CalcNewPath()
    {
        
        int wanderLength = Random.Range(100, 200);
        randomPath = new Vector3(originPosition.x+Random.Range(-wanderLength, wanderLength),originPosition.y+Random.Range(-wanderLength, wanderLength),originPosition.z+Random.Range(-wanderLength, wanderLength));
        return randomPath;
    }

    public void Attack()
    {


        if (attackTimer <= 0)
        {
            Instantiate(projectile, transform.position - new Vector3(0, 0, -25), Quaternion.identity);
            attackTimer = 0.5f;
        }
        else return;
    }

}
