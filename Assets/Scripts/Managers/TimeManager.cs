using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : SaveableEntity, ISaveable
{
    //Count how many time has left
    //initial time = 1 year = 365 days
    //1 day = 5 minuts in real time
    //1 year = 365 * 5 = 1825 minuts = 30.41 hours
    //too long, must have save system

    [SerializeField] private int minutesPerDay = 5;

    private int daysLeft = 365;
    private float timeLeftToday;

    // Start is called before the first frame update
    void Start()
    {
        timeLeftToday = minutesPerDay;
    }

    private void FixedUpdate()
    {
        timeLeftToday -= Time.deltaTime;
        if (timeLeftToday <= 0)
        {
            timeLeftToday = minutesPerDay;
            daysLeft -= 1;
            //TODO: call saveManager to save everything
        }
        if(daysLeft <= 0)
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
