using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traffic_Light_Controller : MonoBehaviour
{
    public float timeTakenBetweenTrafficLight;

    float timefortrafficlight = 0;
    int currenttrafficlight = 0;
    int previoustrafficlight = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<transform.childCount;i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        trafficlight();
    }

    void trafficlight()
    {
        if(Time.time >= timefortrafficlight)
        {
            timefortrafficlight += timeTakenBetweenTrafficLight;
            this.gameObject.transform.GetChild(currenttrafficlight).gameObject.SetActive(false);
            if(previoustrafficlight != currenttrafficlight)
            {
                this.gameObject.transform.GetChild(previoustrafficlight).gameObject.SetActive(true);
            }
            previoustrafficlight = currenttrafficlight;
            if(currenttrafficlight >= transform.childCount -1)
            {
                currenttrafficlight = 0;
            }
            else
            {
                currenttrafficlight += 1;
            }
        }
    }
}
