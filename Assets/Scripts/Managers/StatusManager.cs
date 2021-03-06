using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusManager : Updatable, ISaveable
{

    [SerializeField] Status[] existingStatus;
    [SerializeField] Transform statusGrid;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] TimeManager timeManager;

    private Status[][] statuses;
    private GameObject[][] statusObject;
    private GameObject[][] inspectedStatus;

    // Start is called before the first frame update
    void Start()
    {
        //Spawn all status first;
        statuses = new Status[3][];
        for(int i = 0; i < statuses.Length; i++)
        {
            statuses[i] = new Status[existingStatus.Length];
            for(int j = 0; j < existingStatus.Length; j++)
            {
                statuses[i][j] = new Status(existingStatus[j].beesToChangePerDay, existingStatus[j].icon, false, 0, existingStatus[j].coolDown);
                //statuses[i][j].isActivate = false;
                //statuses[i][j].lastHappenedDay = 0;
            }
        }
        statusObject = new GameObject[statuses.Length][];
        inspectedStatus = new GameObject[statuses.Length][];
        for (int i = 0; i < statuses.Length; i++)
            {
                statusObject[i] = new GameObject[existingStatus.Length];
                inspectedStatus[i] = new GameObject[existingStatus.Length];
            for (int j = 0; j < statuses[i].Length; j++)
                {
                    GameObject icon = statuses[i][j].icon;
                    if (icon == null) continue;
                    //save reference for later use
                    statusObject[i][j] = GameObject.Instantiate(icon, statusGrid);
                    statusObject[i][j].SetActive(false);
                }
        }
    }

    public int CalculateDeadBees(int index)
    {
        int num = 0;
        for (int j = 0; j < statuses[index].Length; j++)
        {
            if (statuses[index][j].isActivate)
            {
                num += statuses[index][j].beesToChangePerDay;
            }
        }

        return num;
    }

    public void InspectStatus(int index)
    {
        //Show current status
        for(int i = 0; i < statusObject[index].Length; i++)
        {
            if (statuses[index][i].isActivate)
            {
                inspectedStatus[index][i] = statusObject[index][i];
            }
            else
            {
                inspectedStatus[index][i] = null;
            }
        }
        ShowStatus(index);
    }

    public void ShowStatus(int index)
    {
        for(int i = 0; i < inspectedStatus[index].Length; i++)
        {
            if (inspectedStatus[index][i] == null)
            {
                statusObject[index][i].SetActive(false);
            }
            else
            {
                inspectedStatus[index][i].SetActive(true);
            }
        }
    }

    public void ActivateStatus(int hiveIndex, int statusIndex)
    {
        statuses[hiveIndex][statusIndex].isActivate = true;
    }

    public void DeactivateStatus(int hiveIndex, int statusIndex)
    {
        statuses[hiveIndex][statusIndex].isActivate = false;
        statuses[hiveIndex][statusIndex].lastHappenedDay = timeManager.GetCurrentDay();
    }

    public void ActivateRandomStatus()
    {
        //50% nothing happened, 50% bad status
        for (int i = 0; i < 3; i++)
        {
            float result = UnityEngine.Random.Range(0f, 1f);
            if (result < 0.5)
            {
                Status status = statuses[i][UnityEngine.Random.Range(0, statuses[i].Length)];
                if ((status.lastHappenedDay + status.coolDown) <= timeManager.GetCurrentDay())
                {
                    status.isActivate = true;
                    status.lastHappenedDay = timeManager.GetCurrentDay();
                }

            }
        }
    }

    public void HideStatus(int index)
    {
        for (int i = 0; i < inspectedStatus[index].Length; i++)
        {
            if (inspectedStatus[index][i] == null) continue;
            inspectedStatus[index][i].SetActive(false);
        }
    }

    public void HideStatusByName(int index, string name)
    {
        for (int i = 0; i < inspectedStatus[index].Length; i++)
        {
            if (inspectedStatus[index][i] == null) continue;
            if (!inspectedStatus[index][i].name.Contains(name)) continue;
            inspectedStatus[index][i].SetActive(false);
            inspectedStatus[index][i] = null;
            DeactivateStatus(index, i);
        }
    }

    [ContextMenu("test activate status")]
    public void TestActivateStatus()
    {
        ActivateStatus(0, 0);
        ActivateStatus(0, 3);
        InspectStatus(0);
    }

    [ContextMenu("test hide status")]
    public void TestHideStatus()
    {
        HideStatus(0);
    }

    public override void UpdateGameState()
    {
        ActivateRandomStatus();
    }

    
    public void CaptureState(string uid)
    {
        //Store statuses (isActivate, lastHappendDay) by index
        for(int i = 0;i < statuses.Length;i++){
            for(int j = 0;j < statuses[i].Length; j++){
                PlayerPrefs.SetString(""+i+":"+j, statuses[i][j].isActivate +":"+statuses[i][j].lastHappenedDay);
            }
        }
    }

    public void RestoreState(string uid)
    {
        //restore statuses (isActivate, lastHappenedDay) by index
        //Update statusObject and inspectedStatus according to statuses.isActivate
        //Not neccessary to restore statusObject and inspectedStatus, let player inspect them 
        for(int i = 0;i < statuses.Length;i++){
            for(int j = 0;j < statuses[i].Length; j++){
                string str = PlayerPrefs.GetString(""+i+":"+j);
                string[] state = str.Split(':');
                bool isActivate = bool.Parse(state[0]);
                int lastHappenedDay = Int32.Parse(state[1]);
                statuses[i][j].isActivate = isActivate;
                statuses[i][j].lastHappenedDay = lastHappenedDay;
            }
        }
    }
}
