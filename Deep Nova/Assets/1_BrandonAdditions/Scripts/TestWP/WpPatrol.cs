using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WpPatrol : MonoBehaviour
{
    public float movementSpeed = 6f;
    public float turningSpeed = 1f;
    public string WaypointTag;
    public float WpCountdown = 5f;

    bool IsMoving;
    Vector3 dist;
    bool WpReached;
    GameObject StartingPoint;
    string TargetWpToGo;
    int currentWpNumber;
    Rigidbody rb;
    float currentWpCountdown;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("PatrolNow", 2);
        IsMoving = true;
    }

    public void PatrolNow()
    {
        rb = GetComponent<Rigidbody>();
        StartingPoint = FindClosestWaypoint();
        TargetWpToGo = StartingPoint.gameObject.name;
        currentWpNumber = int.Parse(TargetWpToGo.Split(char.Parse("-"))[1]);
        IsMoving = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (IsMoving)
        {
            GameObject WpToGo = GameObject.Find(WaypointTag + "-" + currentWpNumber);
            Vector3 lookPos = WpToGo.transform.position - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turningSpeed);
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
            /*
            if (WpReached)
            {
                if (CurrentWpCountdown > 0)
                    CurrentWpCountdown -= Time.deltaTime;
                else
                    WpReached = false;
            }
            */
        }

    }
    
    // Function for finding closest waypoint
    public GameObject FindClosestWaypoint()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(WaypointTag);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        Debug.Log("Closest found: " + closest.gameObject.name);
        return closest;
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == WaypointTag && !WpReached)
        {
            WpReached = true;
            if (GameObject.Find(WaypointTag + "-" + (currentWpNumber + 1)))
                currentWpNumber += 1;
            else
                currentWpNumber = 0;
        }
       if (other.tag == "Player")
        {
            //IsMoving = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == WaypointTag && WpReached)
        {
            WpReached = false;
        }

        if (other.tag == "Player")
        {
            IsMoving = false;
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            IsMoving = false;
        }
    }
}
