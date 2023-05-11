using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeSound : MonoBehaviour
{
    AudioSource audioSource;
    public float minPitch = 0.4f;
    private float pitchFromBike;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = minPitch;
    }

    // Update is called once per frame
    void Update()
    {
        pitchFromBike = PlayerMovement.bikesnd.bikeCurrentSpeed;
        if(pitchFromBike < minPitch)
            audioSource.pitch = minPitch;
        else
            audioSource.pitch = pitchFromBike;
    }
}
