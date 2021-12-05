using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
 
    public TextMeshProUGUI coinText, upgradeCoinText;
    public TextMeshProUGUI timeText;
    public TimeScript ts;

    public Camera mainCam;
    public Camera upCam;

    public PlayerController pc;

    int score;

    List<GameObject> resetQue_Obj = new List<GameObject>();
    List<string> resetQue_Type = new List<string>();
    int listLength = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }
    public void UpdateScore(int coinValue)
    {
        score += coinValue;
        coinText.text = "Coins: " + score.ToString();
        upgradeCoinText.text = "Coins: " + score.ToString();
    }

    public void UpdateTime(int time)
    {
        timeText.text = "Time: " + time.ToString();
    }

    public void timePickUp(int time)
    {
        ts.addTime(time);
    }

    public void RemoveObject(string type, GameObject obj)
    {
    //Add to ListS
        if (type == "Coin")
        {
            obj.GetComponent<CircleCollider2D>().enabled = false;
            for (int i = 0; i < 3; i++)
                obj.transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
        }

    //Update List
        resetQue_Type.Add(type);
        resetQue_Obj.Add(obj);
        listLength++;
    }

    public void Restart()
    {
        //Switch Camera
             mainCam.enabled = false;
             upCam.enabled = true;

        //Replace Items
            for (int i = 0; i < listLength; i++) {
                GameObject obj = resetQue_Obj[i];

                if (resetQue_Type[i] == "Coin") {
                    obj.GetComponent<CircleCollider2D>().enabled = true;
                    for (int j = 0; j < 3; j++)
                        obj.transform.GetChild(j).GetComponent<SpriteRenderer>().enabled = true;
                }
                else if (resetQue_Type[i] == "TimePowerUp")
                {
                    
                }
            }

        //Player Postition Reset
            pc.Restart();
    }

    public void Play() {
    //Switch Camera
        mainCam.enabled = true;
        upCam.enabled = false;

    //Restart Time
        ts.startTime();

    //Allow Player Movement
        pc.Play();
    }

    public int getCoins()
    {
        return score;
    }
}
