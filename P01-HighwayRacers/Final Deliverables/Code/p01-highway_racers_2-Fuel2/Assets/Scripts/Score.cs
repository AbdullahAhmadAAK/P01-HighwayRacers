using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using static System.Math;

public class Score : MonoBehaviour
{
    public GameObject FuelMenuUI;
    public static bool GameisNotPaused = true;
    public TextMeshProUGUI timerText;
    public static float fuel;
    public TextMeshProUGUI FuelText;
    public static float score;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        fuel=5f;
        score=0f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
         if (GameisNotPaused)
        {
            if(Time.timeScale == 1)
            {
                score=score+0.1f;
                fuel=fuel-0.05f;
            }

            if(fuel <= 0f && GameisNotPaused)
            {
                 
                Time.timeScale = 0;
                GameisNotPaused = false;
                FuelMenuUI.SetActive(true);
                 
            }  
        }

        string seconds = (Convert.ToInt32(score)).ToString();
        timerText.text="Score: " + seconds;
        string fuelconvert=(Convert.ToInt32(fuel)).ToString();
        FuelText.text="Fuel: "+ fuelconvert;


    }
}