using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : SaveableEntity, ISaveable
{
    //Count how many time has left
    //initial time = 1 year = 365 days
    //1 day = 30 seconds in real time
    //1 year = 365 * 0.5 = 182.5 minuts = 3.041 hours
    //too long, must have save system

    [SerializeField] TextMeshProUGUI dayText;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] private float secondsPerDay = 27;
    [SerializeField] int workingHourStart = 8;
    [SerializeField] int workingHourEnd = 17;

    private int totalDay = 365;
    private float timeLeftToday;
    private int currentTime;
    private int currentDay = 1;
    private float secondsPerHour;
    private float nextCount;


    // Start is called before the first frame update
    void Start()
    {
        timeLeftToday = secondsPerDay;
        currentTime = workingHourStart; 
        secondsPerHour = secondsPerDay / (workingHourEnd - workingHourStart);
        nextCount = secondsPerDay - secondsPerHour;
    }

    private void FixedUpdate()
    {
        timeLeftToday = Mathf.Max(timeLeftToday - Time.deltaTime, 0);
        if (timeLeftToday < nextCount || timeLeftToday <= 0)
        {
            currentTime = currentTime + 1;
            nextCount -= secondsPerHour;
        }
        timeText.text = String.Format("{0}:00", currentTime);
        if (nextCount <= 0 && timeLeftToday <= 0)
        {
            nextCount = secondsPerDay - secondsPerHour;
            timeLeftToday = secondsPerDay;
            currentDay += 1;
            dayText.text = "Day " + currentDay;
            currentTime = workingHourStart;
            //TODO: call saveManager to save everything
        }
        if(currentDay >= totalDay)
        {
            //TODO: load end game scene
        }
        
    }

    public object SaveState()
    {
        //TODO: Save days left
        return null;
    }

    public void RestoreState(object state)
    {
        //TODO: Load days left
    }
}
