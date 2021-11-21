using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HoneyManager : MonoBehaviour, Updatable
{
    //Increase honey amount base on number of bees
    [SerializeField] private TextMeshProUGUI honeyText;
    [SerializeField] private BeeManager beeManager;
    [SerializeField] private float maxHoneyGeneratedPerDay = 2f;
    [SerializeField] private float minHoneyGeneratedPerDay = .1f;

    private float honeyAmount = 0.0f;
    
    public void Update()
    {
        int beeNumber = beeManager.GetBeeNumber();
        int maxBeeNumber = beeManager.GetMaxBeeNumber();

        float ratio = beeNumber / maxBeeNumber;

        float honeyGenerateToday = maxHoneyGeneratedPerDay * ratio;

        if (honeyGenerateToday < minHoneyGeneratedPerDay)
        {
            honeyGenerateToday = minHoneyGeneratedPerDay;
        }

        honeyAmount += honeyGenerateToday;

        honeyText.text = Mathf.Floor(honeyAmount) + "L";
    }
}
