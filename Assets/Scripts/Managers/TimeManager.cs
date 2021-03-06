using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour, ISaveable
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
    [SerializeField] Updatable[] updatables;
    [SerializeField] private int totalDay = 100;
    [SerializeField] MoneyManager moneyManager;

    private float timeLeftToday;
    private int currentTime;
    private int currentDay = 1;
    private float secondsPerHour;
    private float nextCount;
    BeeHive[] beehives;
    private bool shouldStart = false;


    // Start is called before the first frame update
    void Start()
    {
        timeLeftToday = secondsPerDay;
        currentTime = workingHourStart; 
        secondsPerHour = secondsPerDay / (workingHourEnd - workingHourStart);
        nextCount = secondsPerDay - secondsPerHour;
        beehives = GetComponents<BeeHive>();
    }

    public void StartGame()
    {
        shouldStart = true;
    }

    private void FixedUpdate()
    {
        if (!shouldStart) return;
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
            //for(int i=0; i<beehives.Length; i++)
            //{
            //    beehives[i].paralyzed = true;
            //}
            UpdateGameStates();
            SavingSystem.Save();
        }
        if(currentDay >= totalDay)
        {
            MoneyRecord.Record(moneyManager.GetAmount());
            SceneManager.LoadScene(2);
        }
        
    }

    public void UpdateGameStates()
    {
        for(int i = 0; i< updatables.Length; i++)
        {
            updatables[i].UpdateGameState();
        }
    }

    public int GetCurrentDay()
    {
        return currentDay;
    }

    public void CaptureState(string uid)
    {
        PlayerPrefs.SetInt(uid,currentDay);
    }

    public void RestoreState(string uid)
    {
        currentDay = PlayerPrefs.GetInt(uid);
        dayText.text = "Day " + currentDay;
    }
}
