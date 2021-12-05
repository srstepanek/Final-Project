using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    float timeSinceStart;
    const int timeLimit = 3;
    bool game = true;

    void Start()
    {
        timeSinceStart = 0;
    }

    void Update()
    {
        if (game) {
            //Update Time
            timeSinceStart += Time.deltaTime;
            int timeRemaining = (int)Mathf.Ceil(timeLimit - timeSinceStart);
            LevelManager.instance.UpdateTime(timeRemaining);

            //Check if out of time
            if (timeRemaining <= 0) //End Game
            {
                LevelManager.instance.Restart();
                LevelManager.instance.UpdateTime(0);
                game = false;
            }
        }
    }

    public void addTime(int t) {
        timeSinceStart += t;
    }

    public void Restart() {
        timeSinceStart = 0;
    }

    public void startTime()
    {
        timeSinceStart = 0;
        game = true;
    }
}
