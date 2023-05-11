using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class DestCar : MonoBehaviour
{
    public AudioSource audioSource;
    public Transform dust;
    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
        dust.GetComponent<ParticleSystem>().enableEmission = false;
    }

    // Update is called once per frame

    IEnumerator OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "tri")
        {
            gameObject.SetActive(false);
            transform.position = startPosition;
            Debug.Log("Hit Obstacle");
            audioSource.Play();
            dust.GetComponent<ParticleSystem>().enableEmission = true;
            StartCoroutine(stopSparkle1());
        }

        yield return new WaitForSeconds(2);
        gameObject.SetActive(true);
    }

    IEnumerator stopSparkle1()
    {
        Debug.Log("Dust");
        yield return new WaitForSeconds(.4f);
        dust.GetComponent<ParticleSystem>().enableEmission = false;
    }

}

