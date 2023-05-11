using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScore : MonoBehaviour
{
    public Text CurrentScore;
    public Text HighScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        CurrentScore.text = ""+Mathf.Floor(PlayerPrefs.GetFloat("currentScore"));
        HighScore.text= "" + Mathf.Floor(PlayerPrefs.GetFloat("highScore"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
