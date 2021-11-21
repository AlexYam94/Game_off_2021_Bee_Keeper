using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : SaveableEntity, ISaveable
{

    List<Status> statuses;


    private void Awake()
    {
        statuses = new List<Status>();
        //TODO: add status to list and set status to disable
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int[] CalculateDeadBees()
    {
        int[] nums = new int[statuses.Count];

        //TODO: calculate how many bees dead
        for(int i = 0; i < statuses.Count; i++)
        {
            nums[i] = statuses[i].GetBeesToChangePerDay();
        }

        return nums;
    }

    public void RestoreState(object state)
    {
        //Get statuses from state
        statuses = (List<Status>)state;
    }

    public object SaveState()
    {
        //Save statues
        return statuses;
    }
}
