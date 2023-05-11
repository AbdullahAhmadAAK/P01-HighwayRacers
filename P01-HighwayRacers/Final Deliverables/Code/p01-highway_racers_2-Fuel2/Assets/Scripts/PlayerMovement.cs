using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public TextMeshProUGUI timerText;

    //coin collection
    public static int numberOfCoins;
    public Text coinsText;

    public static float movementSpeed = 5f;
    public float jumpForce = 4f;
    public float speed = 5f;
    public float rotationSpeed = 5f;
    public Transform target;
    public AudioSource audioSource;

    public static PlayerMovement bikesnd;

    public float bikeMaxSpeed = 120f; //km per hour
    public static float currSpeed = 9f;
    public static float currSpeed1 = 0f;
    public float bikeCurrentSpeed = 0f;
    int bike_lives = 3;
    
    public bool moveLeft = false;
    public bool moveRight = false;
    public bool moveReturn = false;


    // Start is called before the first frame update
    void Start()
    {
        currSpeed = 9f;
        bikesnd = this;
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        //currSpeed += Time.deltaTime * 1.1f;
        // rear_tyre = GameObject.FindGameObjectWithTag("RearTyre");
        //Coin Collection
        numberOfCoins = 0;    
    }

    // Update is called once per frame put its contents into a funciton (moveRight, moveLeft etc)
    void Update()
    {
        //increase speed on increasing distance
        currSpeed += (Time.deltaTime/8);
        movementSpeed =Mathf.Min(movementSpeed+0.1f,8);

        if (currSpeed > 15f) { currSpeed = 15f; }


        float horizontalInput = Input.GetAxis("Horizontal"); // camelCase as this is variable
        float verticalInput = Input.GetAxis("Vertical"); // camelCase as this is variable

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);
        transform.Translate(Vector3.left * currSpeed * Time.deltaTime);

        currSpeed1 = (rb.velocity.magnitude * 10f) / bikeMaxSpeed;
        if(currSpeed1 > 0.9f)
            bikeCurrentSpeed = 0.9f;
        else
            bikeCurrentSpeed = currSpeed1;        

        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {

            //var step = speed * Time.deltaTime;
            float angle = Mathf.LerpAngle(transform.eulerAngles.x, 45, Time.deltaTime*rotationSpeed);
            transform.localEulerAngles = new Vector3(angle, 90, 0);
            //transform.localEulerAngles = new Vector3(Mathf.ler45, 90, 0);

            //transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, step);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            float angle = Mathf.LerpAngle(transform.eulerAngles.x, -45, Time.deltaTime * rotationSpeed);
            transform.localEulerAngles = new Vector3(angle, 90, 0);
            //var step = speed * Time.deltaTime;

            //transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, step);
        }
        else
        {
            float angle = Mathf.LerpAngle(transform.eulerAngles.x, 0, Time.deltaTime * rotationSpeed);
            transform.localEulerAngles = new Vector3(angle, 90, 0);

        }
        if (moveLeft)
        {
            //rb.velocity = new Vector3(-movementSpeed*Time.deltaTime, rb.velocity.y,rb.velocity.z);
            transform.position += Vector3.left* movementSpeed* Time.deltaTime;
            //rb.AddForce(Vector3.left * speed, ForceMode.Impulse);

            float angle = Mathf.LerpAngle(transform.eulerAngles.x, -45, Time.deltaTime * rotationSpeed);
            transform.localEulerAngles = new Vector3(angle, 90, 0);
        }
        if (moveRight)
        {
            //rb.velocity = new Vector3(movementSpeed* Time.deltaTime, rb.velocity.y, rb.velocity.z);
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;

            //rb.AddForce(Vector3.right * speed, ForceMode.Impulse);

            float angle = Mathf.LerpAngle(transform.eulerAngles.x, 45, Time.deltaTime * rotationSpeed);
            transform.localEulerAngles = new Vector3(angle, 90, 0);
        }
        if (moveReturn)
        {
            float angle = Mathf.LerpAngle(transform.eulerAngles.x, 0, Time.deltaTime * rotationSpeed);
            transform.localEulerAngles = new Vector3(angle, 90, 0);
            moveReturn = false;
        }

        /*

        if(Input.GetKeyDown("Up")) 
        {
            // rear_tyre.rotation = new Vector3(0,0,1);
            transform.Rotate(Vector3.up * 10 * Time.deltaTime);
        }

        */
        //coin collection
        coinsText.text = "" + numberOfCoins;
    }

    public void MoveLeft()
    {
        moveLeft = true;
        moveRight = false;
        moveReturn = false;   
    }
    public void MoveRight()
    {
        moveRight = true;
        moveLeft = false;
        moveReturn = false;
    }

    public void OnUp()
    {
        moveReturn = true;
        moveLeft = false;
        moveRight = false;
    }
}