using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeMenuScript : MonoBehaviour
{
    public static UpgradeMenuScript instance;

    public float maxSpeed, maxJump;
    public int maxCoinMod;

    public Text speed_CostGUI, jump_CostGUI, coinMod_CostGUI;
    public Text speed_LevelGUI, jump_LevelGUI, coinMod_LevelGUI;

    UpgradeTemplate speed;
    UpgradeTemplate jump;
    UpgradeTemplate coinMod;

    void Start()
    {
        speed = new UpgradeTemplate(1, maxSpeed, speed_CostGUI, speed_LevelGUI);
        jump = new UpgradeTemplate(3, maxJump, jump_CostGUI, jump_LevelGUI);
        coinMod = new UpgradeTemplate(5, maxCoinMod, coinMod_CostGUI, coinMod_LevelGUI);

        if (instance == null)
        {
            instance = this;
        }
    }

    public void Upgrade(string up)
    {
        int coins = LevelManager.instance.getCoins();

        if (up == "Speed")
        {
            speed.upgrade(coins);
        }
        else if (up == "Jump")
        {
            jump.upgrade(coins);
        }
        else if (up == "CoinMod")
        {
            coinMod.upgrade(coins);
        }
    }

    public float getMod(string up)
    {
        if (up == "Speed")
        {
            return speed.getModifer();
        }
        else if (up == "Jump")
        {
            return jump.getModifer();
        }
        else if (up == "CoinMod")
        {
            return coinMod.getModifer() + 1;
        }

        return 1;
    }
}
