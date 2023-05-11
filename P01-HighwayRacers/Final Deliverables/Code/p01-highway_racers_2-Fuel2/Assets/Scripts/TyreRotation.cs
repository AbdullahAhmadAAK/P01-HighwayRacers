using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TyreRotation : MonoBehaviour
{
    public Transform wheelFrontTransform;
    public Transform wheelFrontCenter;
    public Transform wheelRearTransform;
    public Transform wheelRearCenter;

    public float rotationSpeed = 10000;

    public Transform GameObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
        // print(GameObject.eulerAngles.x);
        // rotationDegreeCount = new Vector3(0,0,0);
        // lastRotation = GetCurrentRotation();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        /*
        float thisRotation = GetCurrentRotation();
        while(thisRotation < lastRotation-180f) thisRotation += 360f;
        while(thisRotation > lastRotation+180f) thisRotation -= 360f;
        rotationDegreeCount += thisRotation - lastRotation;
        lastRotation = thisRotation;
        */

        // print(GameObject.eulerAngles.x);

        // local and global transform. entire body linked to tyres through joints

        
        // wheelFrontTransform.Rotate(verticalInput, 0, 0);
        // wheelRearTransform.Rotate(verticalInput, 0, 0);

        wheelFrontTransform.RotateAround(wheelFrontCenter.position, transform.forward, verticalInput * rotationSpeed * Time.deltaTime);
        wheelRearTransform.RotateAround(wheelRearCenter.position, transform.forward, verticalInput * rotationSpeed * Time.deltaTime);
        /*

        wheelFrontTransform.RotateAround(wheelFrontCenter.position, transform.left, verticalInput * rotationSpeed * Time.deltaTime);
        wheelRearTransform.RotateAround(wheelRearCenter.position, transform.right, verticalInput * rotationSpeed * Time.deltaTime);
        
        */

        // wheelFrontTransform.RotateAround(wheelFrontCenter.position,  Vector3.left+ rotationDegreeCount, verticalInput * rotationSpeed * Time.deltaTime);
        // wheelRearTransform.RotateAround(wheelRearCenter.position, Vector3.left+ rotationDegreeCount, verticalInput * rotationSpeed * Time.deltaTime);
        
    }

    public float GetCurrentRotation()
    {
        return Mathf.Atan2(transform.up.y, transform.up.x) * Mathf.Rad2Deg;
    }
}
