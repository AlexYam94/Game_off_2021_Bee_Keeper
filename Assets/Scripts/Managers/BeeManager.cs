using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeManager : Updatable, ISaveable
{
    //Calculate bee numbers each day end
    //Go through all status
    //Each status represent a number
    //If status is not present, number is zero
    //If status is presented, number is less than zero
    //add up all status numbers and a base number, which is how many bees will be added each day

    [SerializeField] private int beesToAddPerDay = 300;
    [SerializeField] private int maxBeeNumber = 10000;
    [SerializeField] private int initialBeeNumber = 1000;
    [SerializeField] private StatusManager statusManager;

    private int[] currentBees = new int[3];

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            currentBees[i] = initialBeeNumber;
        }

    }

    internal int GetBeeNumber(int index)
    {
        return currentBees[index];
    }

    internal int GetMaxBeeNumber()
    {
        return maxBeeNumber;
    }
    public override void UpdateGameState()
    {
        for (int i = 0; i < 3; i++)
        {
            //get bees to add from status manager and add them to currentBees;
            currentBees[i] += beesToAddPerDay + statusManager.CalculateDeadBees(i);
            if (currentBees[i] < 0) currentBees[i] = 0;
        }
    }

    public void CaptureState(string uid)
    {
        PlayerPrefs.SetInt(uid+"0",currentBees[0]);
        PlayerPrefs.SetInt(uid+"1",currentBees[1]);
        PlayerPrefs.SetInt(uid+"2",currentBees[2]);
    }

    public void RestoreState(string uid)
    {
        currentBees[0] = PlayerPrefs.GetInt(uid+"0");
        currentBees[1] = PlayerPrefs.GetInt(uid+"1");
        currentBees[2] = PlayerPrefs.GetInt(uid+"2");
    }

}
