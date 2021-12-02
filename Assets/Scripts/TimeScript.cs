using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    float timeSinceStart;
    public int timeLimit;

    void Start()
    {
        timeSinceStart = 0;
    }

    void Update()
    {
    //Update Time
        timeSinceStart += Time.deltaTime;
        int timeRemaining = (int) Mathf.Ceil(timeLimit - timeSinceStart);
        timerText.text = "Time: " + timeRemaining.ToString();

    //Check if out of time
        if(timeRemaining <= 0)
        {
            //Activate Death Animation
            //Pull Up Menu
            //Reset Objects

            timerText.text = "Time: 0";
        }
    }

    public void addTime(int t) {
        timeLimit += t;
    }

    public void Restart() {
        timeSinceStart = 0;
    }
}
