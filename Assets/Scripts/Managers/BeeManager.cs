using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeManager : SaveableEntity, ISaveable, Updatable
{
    //Calculate bee numbers each day end
    //Go through all status
    //Each status represent a number
    //If status is not present, number is zero
    //If status is presented, number is less than zero
    //add up all status numbers and a base number, which is how many bees will be added each day

    [SerializeField] private int beesToAddPerDay = 300;
    [SerializeField] private int maxBeeNumber = 9999;
    [SerializeField] private int initialBeeNumber = 1000;

    private int currentBees;

    private void Start()
    {
        currentBees = initialBeeNumber;
    }

    internal int GetBeeNumber()
    {
        return currentBees;
    }

    internal int GetMaxBeeNumber()
    {
        return maxBeeNumber;
    }
    void Updatable.Update()
    {
        currentBees += beesToAddPerDay;
        //TODO: get bees to add from status manager and add them to currentBees;
    }

    public void RestoreState(object state)
    {
        //TODO: Load number of bees and status
    }

    public object SaveState()
    {
        //TODO: Save number of bees and status
        return null;
    }

}
