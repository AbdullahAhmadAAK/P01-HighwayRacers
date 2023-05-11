using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    public GameObject[] Cars;

    int ram = 0;
    private void Start()
    {
        spawn();
    }

    void spawn()
    {
       for(int i=0;i<transform.childCount;i++)
        {
            ram = Random.Range(0, Cars.Length);
            // Cars[ram].GetComponent<Car_AI>().currentTrafficRoute = this.gameObject;
            // Cars[ram].GetComponent<Car_AI>().currentWapointNumber = i;
            Instantiate(Cars[ram], gameObject.transform.GetChild(i).transform.position, gameObject.transform.GetChild(i).transform.rotation);
        }
    }
}
