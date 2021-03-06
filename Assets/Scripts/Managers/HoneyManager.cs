using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HoneyManager : Updatable, ISaveable
{
    //Increase honey amount base on number of bees
    [SerializeField] private TextMeshProUGUI honeyText;
    [SerializeField] private BeeManager beeManager;
    [SerializeField] private float maxHoneyGeneratedPerDay = 2f;
    [SerializeField] private float minHoneyGeneratedPerDay = .1f;
    [SerializeField] private BeehiveManager beehiveManager;

    private float[] honeyAmount = new float[3];
    private float maxHoneyAmount = 50f;
    private float displayAmount = 0f;
    
    public override void UpdateGameState()
    {
        for (int index = 0; index < 3; index++)
        {
            float beeNumber = beeManager.GetBeeNumber(index);
            float maxBeeNumber = beeManager.GetMaxBeeNumber();

            float ratio = beeNumber / maxBeeNumber;

            float honeyGenerateToday = maxHoneyGeneratedPerDay * ratio;

            if (honeyGenerateToday < minHoneyGeneratedPerDay)
            {
                honeyGenerateToday = minHoneyGeneratedPerDay;
            }

            float newAmount = honeyAmount[index] + honeyGenerateToday;

            if (newAmount < maxHoneyAmount)
                honeyAmount[index] += honeyGenerateToday;
        }
    }

    public void HarvestHoney(int index)
    {
        displayAmount += honeyAmount[index];
        honeyAmount[index] = 0;
        honeyText.text = Math.Round(displayAmount, 1) + "L";
    }

    public float GetHoneyAmount()
    {
        return displayAmount;
    }

    public void ClearHoney()
    {
        displayAmount = 0;
        honeyText.text = Math.Round(displayAmount, 1) + "L";
    }

    public void CaptureState(string uid){
        PlayerPrefs.SetFloat(uid+"displayAmount", displayAmount);
        PlayerPrefs.SetFloat(uid+"honeyAmount0",honeyAmount[0]);
        PlayerPrefs.SetFloat(uid+"honeyAmount1",honeyAmount[1]);
        PlayerPrefs.SetFloat(uid+"honeyAmount2",honeyAmount[2]);
    }

    public void RestoreState(string uid){
        displayAmount = PlayerPrefs.GetFloat(uid+"displayAmount");
        honeyAmount[0] = PlayerPrefs.GetFloat(uid+"honeyAmount0");
        honeyAmount[1] = PlayerPrefs.GetFloat(uid+"honeyAmount1");
        honeyAmount[2] = PlayerPrefs.GetFloat(uid+"honeyAmount2");
        honeyText.text = Math.Round(displayAmount, 1) + "L";
    }
}
