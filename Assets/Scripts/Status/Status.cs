using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "HiveStatus")]
public class Status : ScriptableObject
{
    public int beesToChangePerDay;
    public GameObject icon;
    public bool isActivate = false;
    public int lastHappenedDay = 0;
    public int coolDown = 10;

    public Status(int beesToChangePerDay, GameObject icon, bool isActivate, int lastHappenedDay, int coolDown)
    {
        this.beesToChangePerDay = beesToChangePerDay;
        this.icon = icon;
        this.isActivate = isActivate;
        this.lastHappenedDay = lastHappenedDay;
        this.coolDown = coolDown;
    }
}
