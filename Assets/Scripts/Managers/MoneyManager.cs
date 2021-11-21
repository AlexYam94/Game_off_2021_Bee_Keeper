using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : SaveableEntity
{
    [SerializeField] TextMeshProUGUI moneyText;

    private int moneyAmount = 5000;

    public void EarnMoney(int amount)
    {
        moneyAmount += amount;
        moneyText.text = ""+moneyAmount;
    }

    public bool SpendMoney(int amount)
    {
        if(moneyAmount < amount)
        {
            return false;
        }
        moneyAmount -= amount;
        moneyText.text = "" + moneyAmount;
        return true;
    }

}
