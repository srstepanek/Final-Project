using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    float timeSinceStart;
    const int timeLimit = 3;

    void Start()
    {
        timeSinceStart = 0;
    }

    void Update()
    {
    //Update Time
        timeSinceStart += Time.deltaTime;
        int timeRemaining = (int) Mathf.Ceil(timeLimit - timeSinceStart);
        LevelManager.instance.UpdateTime(timeRemaining);
     
        //Check if out of time
        if (timeRemaining <= 0) //End Game
        {
            //Activate Death Animation
            //Pull Up Menu
            //Reset Objects
            LevelManager.instance.UpdateTime(0);
        }
    }

    public void addTime(int t) {
        timeSinceStart += t;
    }

    public void Restart() {
        timeSinceStart = 0;
    }
}
