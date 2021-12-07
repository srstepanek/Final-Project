using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelFinish : MonoBehaviour
{

    public GameObject winScreen;
    bool isWin = false;
    void OnTriggerEnter2D(Collider2D otherObject)
    {
        if(otherObject.tag == "Player")
        {
            winScreen.SetActive(true);
         

        }
    }
}
