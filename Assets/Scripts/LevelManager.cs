using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI timeText;
    public TimeScript ts;

    public GameObject prefab_TimePickUp;
    public GameObject prefab_Coin;

    int score;
    List<Vector2> resetQue_Loc;
    List<string> resetQue_Type;
    int listLength = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void UpdateScore(int coinValue)
    {
        score += coinValue;
        coinText.text = "X" + score.ToString();
    }

    public void UpdateTime(int time)
    {
        timeText.text = "Time: " + time.ToString();
    }

    public void timePickUp(int time)
    {
        ts.addTime(time);
    }

    public void RemoveObject(string type, Vector2 loc)
    {
        resetQue_Type.Add(type);
        resetQue_Loc.Add(loc);
        listLength++;
    }

    public void Restart()
    {
        for (int i =0; i < listLength; i++) {
            GameObject obj;
            if (resetQue_Type[i] == "Coin") {
                obj = GameObject.Instantiate(prefab_Coin);
            }
            else if (resetQue_Type[i] == "TimePowerUp")
            {
                obj = GameObject.Instantiate(prefab_TimePickUp);
            }
            else
                obj = new GameObject();

            obj.transform.position = resetQue_Loc[i];
        }
    }
}
