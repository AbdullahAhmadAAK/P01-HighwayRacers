using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime=Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t=Time.time- startTime;
        string minutes = ((int) t / 60).ToString();
        string seconds = (t).ToString("f1");
        timerText.text="Time:" + seconds;
      
    }
}
