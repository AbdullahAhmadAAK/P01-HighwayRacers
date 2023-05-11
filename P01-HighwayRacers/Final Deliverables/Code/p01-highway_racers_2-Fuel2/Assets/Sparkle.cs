using System.Collections;
using UnityEngine;

public class Sparkle : MonoBehaviour
{
    public Transform sparkle;

    void Start()
    {
        sparkle.GetComponent<ParticleSystem>().enableEmission = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "tri")
        {
            Debug.Log("Hit Obstacle");
            sparkle.GetComponent<ParticleSystem>().enableEmission = true;
            StartCoroutine (stopSparkle());
        }
    }

    IEnumerator stopSparkle()
    {
        Debug.Log("Sparkling");
        yield return new WaitForSeconds (.4f);
        sparkle.GetComponent<ParticleSystem>().enableEmission = false;
    }
}
