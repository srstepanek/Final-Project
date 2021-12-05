using TMPro;
using UnityEngine.UI;

public class UpgradeTemplate
{
    int currentLevel = 0, maxLevel = 5;
    int cost = 1;
    double maxModifer;

    Text costGUI;
    Text levelGUI;

    public UpgradeTemplate(int cost, float maxMod, Text costGUI, Text levelGUI)
    {
        this.cost = cost;
        maxModifer = maxMod;
        this.costGUI = costGUI;
        this.levelGUI = levelGUI;

        UpdateText();
    }

    public void UpdateText()
    {
        costGUI.text = "COST: " + cost.ToString();
        levelGUI.text = "LEVEL: " + currentLevel.ToString() + "/" + maxLevel.ToString();
    }

    public void upgrade(int coins) { 
        if (coins >= cost && currentLevel + 1 <= maxLevel) {
        //Update Level, coins, and cost
            currentLevel++;
            LevelManager.instance.UpdateScore(-cost);
            cost = cost * 2;

        //Update Gui
            costGUI.text = "COST: " + cost.ToString();

            UpdateText();
        }
    }

    public float getModifer() {
        return (float)((maxModifer / maxLevel) * currentLevel);
    }
}
