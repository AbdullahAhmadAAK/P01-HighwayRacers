using UnityEngine;

public class obstacle : MonoBehaviour
{
    public float forceApplied = 50;
 
    void OnCollisionEnter(Collision other)
    {
        Debug.Log ("Adding Force!");
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce (0, forceApplied, 0);
        }
    }
}
