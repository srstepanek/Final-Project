using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeTemplate
{
    int currentLevel = 0, maxLevel = 5;
    int cost = 1;
    double maxModifer;

    TextMeshProUGUI costGUI;
    TextMeshProUGUI levelGUI;

    UpgradeTemplate(int cost, int maxMod, TextMeshProUGUI costGUI, TextMeshProUGUI levelGUI)
    {
        this.cost = cost;
        maxModifer = maxMod;
        this.costGUI = costGUI;
        this.levelGUI = levelGUI;
    }

    public void upgrade(int coins) { 
        if (coins >= cost) {
        //Update Level, coins, and cost
            currentLevel++;
            LevelManager.instance.UpdateScore(-coins);
            cost = cost * 2;

        //Update Gui
            costGUI.text = "COST: " + cost.ToString();
        }
    }

    public double getModifer() {
        return (maxModifer / maxLevel) * currentLevel;
    }
}
