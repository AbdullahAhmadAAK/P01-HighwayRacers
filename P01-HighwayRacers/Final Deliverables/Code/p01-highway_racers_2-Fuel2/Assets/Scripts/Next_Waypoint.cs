using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next_Waypoint : MonoBehaviour
{
    public GameObject[] Waypoints;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            if(Waypoints.Length <= 0)
               other.gameObject.GetComponent<Car_AI>().nextWaypoint = null;

            else
            {
                int ram = Random.Range(0, Waypoints.Length);
                other.gameObject.GetComponent<Car_AI>().nextWaypoint = Waypoints[ram];
            }
        }
    }
}
