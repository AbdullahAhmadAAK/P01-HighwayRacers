using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip collision_sound;
    public AudioClip coin_sound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.tag == "tri")
        {
            Debug.Log("Hit Obstacle");
            audioSource.PlayOneShot(collision_sound, 0.7f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Debug.Log("Hit Coin");
            audioSource.PlayOneShot(coin_sound, 0.7f);
        }
    }
}
