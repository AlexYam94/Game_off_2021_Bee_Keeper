using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MoneyManager : MonoBehaviour, ISaveable
{
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] float dollarPerHoney = 5;

    private int moneyAmount = 100;

    private void Start()
    {
        moneyText.text = "$" + moneyAmount;
    }

    public void SellHoney(float amount)
    {
        double roundedAmount = Math.Round(amount, 1);
        EarnMoney(Mathf.RoundToInt((float)(roundedAmount * dollarPerHoney)));

    }

    public void EarnMoney(int amount)
    {
        moneyAmount += amount;
        moneyText.text = "$"+moneyAmount;
    }

    public int GetAmount()
    {
        return moneyAmount;
    }

    public bool SpendMoney(int amount)
    {
        if(moneyAmount < amount)
        {
            return false;
        }
        moneyAmount -= amount;
        moneyText.text = "$" + moneyAmount;
        return true;
    }

    public void CaptureState(string uid){
        PlayerPrefs.SetInt("uid",moneyAmount);
    }

    public void RestoreState(string uid){
        moneyAmount = PlayerPrefs.GetInt("uid");
        moneyText.text = "$" + moneyAmount;
    }

}
